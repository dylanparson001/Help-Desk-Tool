using iGPS_Help_Desk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Controllers
{
    public  class SiteController : BaseController
    {
        private readonly IIgpsDepotGlnRepository _igpsDepotGlnRepository;

        public SiteController(IIgpsDepotGlnRepository igpsDepotGlnRepository)
        {
            _igpsDepotGlnRepository = igpsDepotGlnRepository;
        }
        public async Task<string> GetSiteIDAsync()
        {
            return await _igpsDepotGlnRepository.GetSiteID();
        }
    }
}
