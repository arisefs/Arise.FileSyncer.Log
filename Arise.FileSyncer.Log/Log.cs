using System;

namespace Arise.FileSyncer
{
    public enum LogLevel
    {
        Error,
        Warning,
        Info,
        Verbose,
        Debug
    }

    public static class Log
    {
        private static Logger logger = new();

        public static void SetLogger(Logger newLogger)
        {
            logger = newLogger ?? throw new ArgumentNullException(nameof(newLogger));
        }

        public static void Error(string message) => logger.Log(LogLevel.Error, message);
        public static void Warning(string message) => logger.Log(LogLevel.Warning, message);
        public static void Info(string message) => logger.Log(LogLevel.Info, message);
        public static void Verbose(string message) => logger.Log(LogLevel.Verbose, message);
        public static void Debug(string message) => logger.Log(LogLevel.Debug, message);
    }

    public class Logger
    {
        public virtual void Log(LogLevel level, string message)
        {
            Print(Format(level, message));
        }

        protected static void Print(string message)
        {
            Console.WriteLine(message);
        }

        protected static string Format(LogLevel level, string message)
        {
            var now = DateTime.Now;
            var letter = LevelToLetter(level);
            return $"{now.Year:0000}-{now.Month:00}-{now.Day:00} {now.Hour:00}:{now.Minute:00}:{now.Second:00} | {letter}: {message}";
        }

        protected static char LevelToLetter(LogLevel level) => level switch
        {
            LogLevel.Error => 'E',
            LogLevel.Warning => 'W',
            LogLevel.Info => 'I',
            LogLevel.Verbose => 'V',
            LogLevel.Debug => 'D',
            _ => throw new NotImplementedException(),
        };
    }
}
