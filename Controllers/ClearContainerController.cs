using System;
using System.Collections.Generic;
using System.Linq;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Controllers
{
    public class ClearContainerController : BaseController
    {

        public List<IGPS_DEPOT_GLN> GetDnus()
        {
            // Get List of dnus
            List<string> dnuList = _igpsDepotLocationRepository.ReadDnus();
                
            // Check for null
            if(dnuList == null)
            {
                throw new Exception("No DNUs Found");
            }
            // concat '', to items in list
            string stringGlns = ConcatStringFromList(dnuList);
                
            //  Get the containers from IGPS_DEPOT_GLN table
            List<IGPS_DEPOT_GLN> glnList = _igpsDepotGlnRepository.ReadContainersFromList(stringGlns);

            return glnList.OrderBy(x => x.Gln).ToList();
            
        }

        public List<IGPS_DEPOT_GLN> GetContainersFromList(List<string> containerList)
        {
            List<IGPS_DEPOT_GLN> result = new List<IGPS_DEPOT_GLN>();
            string stringGlns = ConcatStringFromList(containerList);

            result = _igpsDepotGlnRepository.ReadContainersFromList(stringGlns);
            
            return result;
        }

        public void ClearContainers(List<string> glnList)
        {
            List<string> listToDelete = new List<string>();
            string stringToDelete;
            
            if (glnList == null) return;
            string stringGlns = ConcatStringFromList(glnList);

            // List from db
            List<IGPS_DEPOT_GLN> listFromDb = _igpsDepotGlnRepository.ReadContainersFromList(stringGlns);

            foreach (IGPS_DEPOT_GLN container in listFromDb)
            {
                listToDelete.Add(container.Gln);
            } 
            stringToDelete =ConcatStringFromList(listToDelete);
            
            _igpsDepotGlnRepository.DeleteGlnsFromList(stringToDelete);
            _igpsDepotLocationRepository.DeleteContainersFromList(stringToDelete);
        }
        
    
        private string ConcatStringFromList(List<string> listOfString)
        {
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }
    }
}