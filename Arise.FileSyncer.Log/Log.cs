using System;

namespace Arise.FileSyncer
{
    public static class Log
    {
        public delegate void DelegateLog(string message);

#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static DelegateLog Error     = (message) => Console.WriteLine(Format("E: " + message));
        public static DelegateLog Warning   = (message) => Console.WriteLine(Format("W: " + message));
        public static DelegateLog Info      = (message) => Console.WriteLine(Format("I: " + message));
        public static DelegateLog Verbose   = (message) => Console.WriteLine(Format("V: " + message));
        public static DelegateLog Debug     = (message) => Console.WriteLine(Format("D: " + message));
#pragma warning restore CA2211 // Non-constant fields should not be visible

        private static string Format(string message)
        {
            var now = DateTime.Now;
            return $"{now.Year:0000}-{now.Month:00}-{now.Day:00} {now.Hour:00}:{now.Minute:00}:{now.Second:00} | {message}";
        }
    }
}
