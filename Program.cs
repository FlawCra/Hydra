using AutoUpdaterDotNET;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hydra
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Init the Sentry SDK
            SentrySdk.Init("https://b1d3b53271f94c57b7bfd8c1b12d43eb@o373397.ingest.sentry.io/5626105");
            // Configure WinForms to throw exceptions so Sentry can capture them.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoUpdater.AppCastURL = "https://api.flawcra.cc/fcheatlauncher/updater.php?updater";
            AutoUpdater.AppTitle = "Hydra";
            AutoUpdater.Synchronous = true;
            AutoUpdater.Start();

            Application.Run(new Form1());
        }
    }
}
