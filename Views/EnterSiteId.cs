using System;
using System.Configuration;
using System.IO;
using System.Security.Policy;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class EnterSiteId : Form
    {
        public EnterSiteId()
        {
            InitializeComponent();
        }

        private void ClickSubmitId(object sender, EventArgs e)
        {
            string siteId = txtSiteId.Text;
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;


                if (settings["siteId"] == null)
                {
                    settings.Add("siteId", siteId);
                }
                else
                {
                    settings["siteId"].Value = siteId;
                }
 
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                Application.Restart();

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}