﻿using iGPS_Help_Desk.Models.Repositories;
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
        protected IgpsDepotGlnRepository _igpsDepotGlnRepository = new IgpsDepotGlnRepository();
        protected IgpsDepotLocationRepository _igpsDepotLocationRepository = new IgpsDepotLocationRepository();
        protected OrderRequestNewHeaderRepository _orderRequestNewHeaderRepository = new OrderRequestNewHeaderRepository();
        protected RollbackRepository _rollbackRepository = new RollbackRepository();
        protected ILogger _logger = Log.ForContext<Igps>();
        protected string ConcatStringFromList(List<string> listOfString)
        {
            listOfString.ForEach(x =>
            {
                x.Trim();
            });
            
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }
        protected string GetCurrentSiteid()
        {
            return ConfigurationManager.AppSettings.Get("siteId");
        }
    }
}