using System;
using System.Configuration;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class EnterSiteId : Form
    {
        public EnterSiteId()
        {
            InitializeComponent();
        }

        private void clickSubmitId(object sender, EventArgs e)
        {
            string siteId = txtSiteId.Text;
            ConfigurationManager.AppSettings.Set("siteId", siteId);

            DialogResult = DialogResult.OK;
        }
    }
}