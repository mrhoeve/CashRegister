using CashRegister.DAL;
using CashRegister.DataModels;
using CashRegister.Forms;
using CashRegister.Model;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace CashRegister
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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

            Context.getInstance().setProduction();
            CurUser.get().isLoggedIn();

            ShowVersionInformation();
            ShowSystemUsers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
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

        private static void ShowVersionInformation()
        {
            logger.Info($"Branche ${GitVersionInformation.BranchName}");

            var assemblyName = typeof(Program).Assembly.GetName().Name;
            var gitVersionInformationType = typeof(Program).Assembly.GetType("GitVersionInformation");
            var fields = gitVersionInformationType.GetFields();

            foreach (var field in fields)
            {
                logger.Info(string.Format("{0}: {1}", field.Name, field.GetValue(null)));
            }
        }

        private static void ShowSystemUsers()
        {
            StringBuilder currentUsers = new StringBuilder();
            currentUsers.Append("Current system users:");
            List<SysteemGebruiker> systemUsers = new List<SysteemGebruiker>();
            systemUsers = Context.getInstance().Get().SysteemGebruiker.ToList();
            foreach (SysteemGebruiker user in systemUsers)
            {
                currentUsers.Append(" - ");
                currentUsers.Append(user.Persoon.GetVolledigeNaam());
            }
            logger.Trace(currentUsers.ToString());
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
            config.AddRule(LogLevel.Warn, LogLevel.Fatal, fileTarget);
#endif

            LogManager.Configuration = config;

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
