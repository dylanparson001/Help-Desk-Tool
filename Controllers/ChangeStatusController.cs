using System.Collections.Generic;
using System.Threading.Tasks;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Controllers
{
    public class ChangeStatusController : BaseController
    {
        public async Task<List<IGPS_DEPOT_LOCATION>> ChangeStatus(string stringGlns, string newStatus, string newSubStatus)
        {
            
            _igpsDepotLocationRepository.ChangeStatus(stringGlns, newStatus);
            _igpsDepotLocationRepository.ChangeSubStatus(stringGlns, newSubStatus);
            
            return await _igpsDepotLocationRepository.ReadContainersFromList(stringGlns);
        }
        
        
    }
}