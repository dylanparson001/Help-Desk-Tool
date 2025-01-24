using iGPS_Help_Desk.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using iGPS_Help_Desk.Repositories;
using System.Configuration;
using Serilog;
using iGPS_Help_Desk.Views;

namespace iGPS_Help_Desk.Controllers
{
    public class BaseController
    {
        public IgpsDepotGlnRepository _igpsDepotGlnRepository = new IgpsDepotGlnRepository();
        public IgpsDepotLocationRepository _igpsDepotLocationRepository = new IgpsDepotLocationRepository();
        public OrderRequestNewHeaderRepository _orderRequestNewHeaderRepository = new OrderRequestNewHeaderRepository();
        public RollbackRepository _rollbackRepository = new RollbackRepository();
        public string ConcatStringFromList(List<string> listOfString)
        {
            listOfString.ForEach(x =>
            {
                x.Trim();
            });
            
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }
        public string GetCurrentSiteid()
        {
            return ConfigurationManager.AppSettings.Get("siteId");
        }
    }
}