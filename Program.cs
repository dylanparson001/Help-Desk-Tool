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
                // Configure Serilog to write log messages to a text file
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("./Log/log.txt", rollingInterval: RollingInterval.Month)
                    .CreateLogger();

                Application.Run(new Igps());

                // Close and flush the log when the application exits
                Log.CloseAndFlush();

            }
 
        }
    }
}
