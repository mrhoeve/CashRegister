using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Setup general exception handling
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (args.IsTerminating)
                logger.Fatal(e, $"General uncaught exception: {e.Message} {e.StackTrace}");
            else
                logger.Warn(e, $"General uncaught exception: {e.Message} {e.StackTrace}");
            //Console.WriteLine("MyHandler caught : " + e.Message);
            //Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
