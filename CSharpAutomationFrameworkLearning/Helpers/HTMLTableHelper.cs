using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace CSharpAutomationFrameworkLearning.Helpers
{
    public class HTMLTableHelper
    {
        private static List<TableDatacollection> _tableDatacollections;

        public static void ReadTable(IWebElement table)
        {
            _tableDatacollections = new List<TableDatacollection>();
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));
                if (colDatas.Count != 0)
                    foreach (var colValue in colDatas)
                    {
                        _tableDatacollections.Add(new TableDatacollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ?
                                         columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });
                        colIndex++;
                    }
                rowIndex++;
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }

            return columnSpecialValue;
        }
        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();
                if (controlToOperate != null && cell != null)
                {
                    if (cell.ControlType == "hyperLink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == controlToOperate
                                               select c).SingleOrDefault();
                        returnedControl?.Click();
                    }
                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();
                        returnedControl?.Click();
                    }
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }

    }
    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }
}
