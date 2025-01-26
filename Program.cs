using System;
using System.Configuration;
using System.Windows.Forms;
using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Models.Repositories;
using iGPS_Help_Desk.Repositories;
using iGPS_Help_Desk.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace iGPS_Help_Desk
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Dependency Injection
            var services = new ServiceCollection();

            // Register Services
            ConfigureServices(services);    

            // Build service proviedr
            ServiceProvider = services.BuildServiceProvider();

            // Logger setup 
            Log.Logger = new LoggerConfiguration()
                // Clear Container Logger
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("ClearContainer"))
                    .WriteTo.File("./Log/Clear-Container-Logs/Clear-Container-Log_.txt", rollingInterval: RollingInterval.Month))
                // Rollback logger
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey("Rollback"))
                    .WriteTo.File("./Log/Rollback-Logs/Rollback-Log_.txt", rollingInterval: RollingInterval.Month))
                // Error Logger
                .WriteTo.File("./Log/General-Error-Logs/Error-Log_.txt", rollingInterval: RollingInterval.Month, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
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

                Application.Run(ServiceProvider.GetRequiredService<Igps>());    

                // Close and flush the log when the application exits
                Log.CloseAndFlush();

            }

        }

        private static void ConfigureServices(ServiceCollection services)
        {

            // Forms
            services.AddTransient<Igps>();
            services.AddTransient<EnterSiteId>();
            services.AddTransient<LoginForm>();
            services.AddTransient<SettingsForm>();
            services.AddTransient<ClearGraisForm>();

            // Repositories
            services.AddScoped<IIgpsDepotGlnRepository, IgpsDepotGlnRepository>();
            services.AddScoped<IIgpsDepotLocationRepository, IgpsDepotLocationRepository>();
            services.AddScoped<IOrderRequestNewHeaderRepository, OrderRequestNewHeaderRepository>();

            // Controllers
            services.AddScoped<ClearContainerController>();
            services.AddScoped<RollbackController>();
            services.AddScoped<CsvFileController>();
            services.AddScoped<MoveContainerController>();
            services.AddScoped<OrderController>();
            services.AddScoped<SiteController>();

        }
    }
}
