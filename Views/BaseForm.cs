using System.Configuration;
using System.Windows.Forms;
using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Views
{
    public partial class BaseForm : Form
    {
        protected string _siteId = ConfigurationManager.AppSettings.Get("siteId");
        protected string _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
