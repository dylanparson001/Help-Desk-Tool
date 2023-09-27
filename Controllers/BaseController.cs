using iGPS_Help_Desk.Models.Repositories;

namespace iGPS_Help_Desk.Controllers
{
    public class BaseController
    {
        protected IgpsDepotGlnRepository _igpsDepotGlnRepository = new IgpsDepotGlnRepository();
        protected IgpsDepotLocationRepository _igpsDepotLocationRepository = new IgpsDepotLocationRepository();
    }
}