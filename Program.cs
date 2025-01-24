using System;
using System.Configuration;
using System.Windows.Forms;
using iGPS_Help_Desk.Views;
using Serilog;

namespace iGPS_Help_Desk
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Logger setup 
            Log.Logger = new LoggerConfiguration()
                // Clear Container Logger
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("ClearContainer"))
                    .WriteTo.File("./Log/ClearContainerLog_.txt", rollingInterval: RollingInterval.Month))
                // Rollback logger
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("Rollback"))
                    .WriteTo.File("./Log/RollbackLog_.txt", rollingInterval: RollingInterval.Month))
                // Error Logger
                .WriteTo.File("./Log/ErrorLog_.txt", rollingInterval: RollingInterval.Month, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                .CreateLogger();


            string siteId = ConfigurationManager.AppSettings.Get("siteId");

            // Show site id form if there is none in the config file
            if (siteId.Length == 0)
            {
                EnterSiteId enterSiteId = new EnterSiteId();
                if (enterSiteId.ShowDialog() == DialogResult.OK)
                {
                    enterSiteId.Close();
                }
            }
            // Show login form
            LoginForm fLogin = new LoginForm();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                fLogin.Close();

                Application.Run(new Igps());

                // Close and flush the log when the application exits
                Log.CloseAndFlush();

            }

        }
    }
}
