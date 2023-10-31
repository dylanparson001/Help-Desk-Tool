using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class BaseForm : Form
    {
        protected string _siteId = ConfigurationManager.AppSettings.Get("siteId");
        protected string _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        protected readonly ChangeStatusController _changeStatusController = new ChangeStatusController();
        protected readonly ClearContainerController _clearContainerController = new ClearContainerController();
        protected readonly CsvFileController _csvFileController = new CsvFileController();
        protected readonly MoveContainerController _moveContainerController = new MoveContainerController();

        protected readonly FacilityContainerStatusRepository _facilityContainerStatusRepository = new FacilityContainerStatusRepository();
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
