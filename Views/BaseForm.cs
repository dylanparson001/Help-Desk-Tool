using System.Configuration;
using System.Windows.Forms;
using iGPS_Help_Desk.Controllers;

namespace iGPS_Help_Desk.Views
{
    public partial class BaseForm : Form
    {
        protected string _siteId = ConfigurationManager.AppSettings.Get("siteId");
        protected string _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        protected readonly ClearContainerController _clearContainerController = new ClearContainerController();
        protected readonly CsvFileController _csvFileController = new CsvFileController();
        protected readonly MoveContainerController _moveContainerController = new MoveContainerController();
        
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
