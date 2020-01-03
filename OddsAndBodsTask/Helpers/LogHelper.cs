using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Helpers
{

    public enum LogType
    {
        Info,
        Error,
        Warning,
        Comment
    }
    public class LogHelper
    {
        public static void SubmitLog(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error - {message}");
                    Console.ResetColor();
                    break;
                case LogType.Warning:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Warning - {message}");
                    Console.ResetColor();
                    break;
                case LogType.Info:
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Info - {message}");
                    Console.ResetColor();
                    break;
                case LogType.Comment:
                    Console.ResetColor();
                    Console.WriteLine($"{message}");
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }
    }
}
