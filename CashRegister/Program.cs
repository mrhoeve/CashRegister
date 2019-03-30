using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace CashRegister
{
    static class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main()
        {
            ConfigureLogger();
            logger.Trace("Application started");
            // Setup general exception handling
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            logger.Trace("Application ended");
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (args.IsTerminating)
                logger.Fatal(e, $"General uncaught exception: {e.Message} {e.StackTrace}");
            else
                logger.Error(e, $"General uncaught exception: {e.Message} {e.StackTrace}");
        }

        private static void ConfigureLogger()
        {
            // Configure NLog, see https://github.com/NLog/NLog/wiki/Configuration-API
            var config = new LoggingConfiguration();
#if DEBUG
            var consoleTarget = new ColoredConsoleTarget("consoleTarget")
            {
                Layout = @"${date:format=dd-MM-yyyy HH\:mm\:ss.fff} ${uppercase:${level}} ${callsite} ${message}"
            };
            config.AddTarget(consoleTarget);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
#endif
            var fileTarget = new FileTarget("fileTarget")
            {
                FileName = "${basedir}/logs/${shortdate}.log",
                Layout = @"${date:format=dd-MM-yyyy HH\:mm\:ss.fff} ${uppercase:${level}} ${callsite} ${message}"
            };
            config.AddTarget(fileTarget);
#if DEBUG
            config.AddRule(LogLevel.Trace,LogLevel.Fatal, fileTarget);
#else
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget);
#endif

            NLog.LogManager.Configuration = config;

            /*
             * Log levels
             * Each log message has associated log level, which identifies how important/detailed the message is. NLog can route log messages based primarily on their logger name and log level.
             *
             * NLog supports the following log levels:
             *
             * Trace - very detailed logs, which may include high-volume information such as protocol payloads. This log level is typically only enabled during development
             * Debug - debugging information, less detailed than trace, typically not enabled in production environment.
             * Info - information messages, which are normally enabled in production environment
             * Warn - warning messages, typically for non-critical issues, which can be recovered or which are temporary failures
             * Error - error messages - most of the time these are Exceptions
             * Fatal - very serious errors!
             *
             */
        }
    }
}
