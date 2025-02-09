﻿using iGPS_Help_Desk.Repositories;
using iGPS_Help_Desk.Views;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace iGPS_Help_Desk
{
    public partial class SettingsForm : BaseForm
    {
        public IgpsDepotGlnRepository igpsDepotGlnRepository { get; set; }
        public SettingsForm()
        {

            InitializeComponent();
            txtSiteId.Text = ConfigurationManager.AppSettings.Get("siteId");
            txtPath.Text = ConfigurationManager.AppSettings.Get("clearContainerPath");

            igpsDepotGlnRepository = new IgpsDepotGlnRepository();
        }

        private async void ClickSaveSettings(object sender, EventArgs e)
        {
            //string siteId = txtSiteId.Text;
            string path = txtPath.Text;
            string siteId = await igpsDepotGlnRepository.GetSiteID();
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;


                // Set site id
                if (settings["siteId"] == null)
                {
                    settings.Add("siteId", siteId);
                }
                else
                {
                    settings["siteId"].Value = siteId;
                }

                

                // Set clear container path
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
                Close();
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void ClickCancel(object sender, EventArgs e)
        {
            Close();
        }

        private void clickLogout(object sender, EventArgs e)
        {

        }
    }
}
