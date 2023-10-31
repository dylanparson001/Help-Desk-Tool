using iGPS_Help_Desk.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace iGPS_Help_Desk.Controllers
{
    public class BaseController
    {
        protected IgpsDepotGlnRepository _igpsDepotGlnRepository = new IgpsDepotGlnRepository();
        protected IgpsDepotLocationRepository _igpsDepotLocationRepository = new IgpsDepotLocationRepository();

        protected string ConcatStringFromList(List<string> listOfString)
        {
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }
    }
}