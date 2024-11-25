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
        protected readonly ClearContainerController _clearContainerController = new ClearContainerController();
        protected readonly CsvFileController _csvFileController = new CsvFileController();
        protected readonly MoveContainerController _moveContainerController = new MoveContainerController();
        protected readonly OrderController _orderController = new OrderController();
        protected readonly RollbackController _rollbackController = new RollbackController();
        protected readonly SiteController _siteController = new SiteController();
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
