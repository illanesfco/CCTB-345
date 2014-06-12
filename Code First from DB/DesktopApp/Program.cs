using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
        }

        const string message = "An unhandled exception occurred in the DesktopApp.{0}{1}";
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Handle Exception
            string exceptionDetail = "Top-Level Exception: {1} {0}{0}Root Exception: {2}{0}{3}";
            Exception root = e.Exception;
            while (root.InnerException != null)
            {
                root = root.InnerException;
            }
            exceptionDetail
                = string.Format(exceptionDetail, Environment.NewLine, e.Exception.Message, root.Message, root.StackTrace);
            LogMessage(string.Format(message, Environment.NewLine, exceptionDetail));
        }

        // Source: http://www.dotnetspider.com/resources/34984-Log-error-messages-text-file-WINDOWS.aspx
        public static void LogMessage(String errorMessage)
        {

        }

    }
}
