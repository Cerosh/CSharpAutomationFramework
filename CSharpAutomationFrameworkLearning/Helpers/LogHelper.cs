using System;
using System.IO;

namespace CSharpAutomationFrameworkLearning.Helpers
{
    public class LogHelper
    {
        private static string _logFileName = String.Format($"{DateTime.Now:yyyymmddhhmmss}");
        private static StreamWriter _streamWriter = null;
        public static void CreateLogFile()
        {
            string directory = @"/Users/ceroshjacobs/Projects/CSharpAutomationFrameworkLearning/";
            if (Directory.Exists(directory))
            {
                _streamWriter = File.AppendText(directory + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(directory);
                _streamWriter = File.AppendText(directory + _logFileName + ".log");
            }
        }
        public static void Write(String logMessage)
        {
            _streamWriter.Write($"{DateTime.Now.ToLongTimeString()}, {DateTime.Now.ToLongDateString()}");
            _streamWriter.WriteLine($" {logMessage}");
            _streamWriter.Flush();
        }
    }
}
