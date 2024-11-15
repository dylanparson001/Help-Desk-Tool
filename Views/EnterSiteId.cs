using iGPS_Help_Desk.Repositories;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class EnterSiteId : Form
    {
        private IgpsDepotGlnRepository igpsDepotGlnRepository;

        public EnterSiteId()
        {
            InitializeComponent();
            igpsDepotGlnRepository = new IgpsDepotGlnRepository();

        }

        private async void ClickSubmitId(object sender, EventArgs e)
        {
            //string siteId = txtSiteId.Text;
            string siteId = await igpsDepotGlnRepository.GetSiteID();
            var folderPath = txtFolderPath.Text;
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                

                if (settings["siteId"] == null || settings["clearContainerPath"] == null)
                {
                    settings.Add("siteId", siteId);
                    settings.Add("clearContainerPath", folderPath);
                }
                else
                {
                    settings["siteId"].Value = siteId;
                    settings["clearContainerPath"].Value = folderPath;
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