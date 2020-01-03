using System;

namespace OddsAndBodsTask.Helpers
{
    /// <summary>
    /// Log Type: Info, Error, Warning, and Content
    /// </summary>
    public enum LogType
    {
        Info,
        Error,
        Warning,
        Comment
    }
    /// <summary>
    /// LogHelper
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// Submits logs for user - can be extended to add logs to database or files or ....
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logType"></param>
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
