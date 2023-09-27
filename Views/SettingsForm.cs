using System;
using System.Configuration;
using System.Windows.Forms;

namespace iGPS_Help_Desk
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();
            txtSiteId.Text = ConfigurationManager.AppSettings.Get("siteId");
            txtPath.Text = ConfigurationManager.AppSettings.Get("clearContainerPath");
        }

        private void clickSaveSettings(object sender, EventArgs e)
        {
            string siteId = txtSiteId.Text;
            string path = txtPath.Text;

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
                if (settings["clearContainerPath"] == null)
                {
                    settings.Add("clearContainerPath", path);
                }
                else
                {
                    settings["clearContainerPath"].Value = path;
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

        private void clickCancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
