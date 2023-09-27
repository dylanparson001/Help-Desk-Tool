using System;
using System.Collections.Generic;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Models.Repositories;

namespace iGPS_Help_Desk.Controllers
{
    public class ChangeStatusController : BaseController
    {


        public List<IGPS_DEPOT_LOCATION> ChangeStatus(string stringGlns, string newStatus, string newSubStatus)
        {
            if (stringGlns == null) throw new Exception("Gln list is empty");
            
            _igpsDepotLocationRepository.ChangeStatus(stringGlns, newStatus);
            _igpsDepotLocationRepository.ChangeSubStatus(stringGlns, newSubStatus);
            
            return _igpsDepotLocationRepository.ReadContainersFromList(stringGlns);
        }
    }
}