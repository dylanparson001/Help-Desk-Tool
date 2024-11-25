using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Controllers
{
    public  class SiteController : BaseController
    {
        public async Task<string> GetSiteIDAsync()
        {
            return await _igpsDepotGlnRepository.GetSiteID();
        }
    }
}
