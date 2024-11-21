using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Controllers
{
    public class ClearContainerController : BaseController
    {
        public async Task<(List<IGPS_DEPOT_GLN>, List<IGPS_DEPOT_LOCATION>)> GetDnus()
        {
            // Get List of dnus
            List<string> dnuList = await _igpsDepotLocationRepository.ReadDnus();

            // Check for null
            if (dnuList == null)
            {
                throw new Exception("No DNUs Found");
            }

            // concat '', to items in list
            string stringGlns = ConcatStringFromList(dnuList);

            //  Get the containers from IGPS_DEPOT_GLN table
            List<IGPS_DEPOT_GLN> glnList = await _igpsDepotGlnRepository.ReadContainersFromList(stringGlns);

            List<IGPS_DEPOT_LOCATION> locationList =
                await _igpsDepotLocationRepository.ReadContainersFromList(dnuList);


            return (glnList.OrderBy(x => x.Gln).ToList(), locationList.OrderBy(x => x.Gln).ToList());
        }

        public async Task<List<IGPS_DEPOT_GLN>> GetContainersFromList(List<string> containerList)
        {
            List<IGPS_DEPOT_GLN> result = new List<IGPS_DEPOT_GLN>();
            string stringGlns = ConcatStringFromList(containerList);

            result = await _igpsDepotGlnRepository.ReadContainersFromList(stringGlns);

            return result;
        }

        public async Task<List<IGPS_DEPOT_LOCATION>> GetLocationContainersFromList(List<string> containerList)
        {
            var result = new List<IGPS_DEPOT_LOCATION>();

            //string stringGlns = ConcatStringFromList(containerList);

            result = await _igpsDepotLocationRepository.ReadContainersFromList(containerList);
            return result;
        }

        public async Task<(List<IGPS_DEPOT_GLN>, int)> GetAllContainers()
        {
            //var result = await _igpsDepotGlnRepository.ReadAllContainers();
            var result = await _igpsDepotGlnRepository.ReadAllContainersBatch();
            return result;
        }

        public async void ClearContainers(List<string> glnList)
        {

            if (glnList == null)
            {
                return;
            }
            if (glnList.Count == 0) {
                return;
            
            }
            int count = await _igpsDepotGlnRepository.GetCountOfTable();


            List<string> listToDelete = new List<string>();
            List<string> listLocationToDelete = new List<string>();
            string stringToDelete;
            string stringLocationToDelete;
            if (glnList == null) return;

            
            string listToRead = ConcatStringFromList(glnList);
            // List from db
            List<IGPS_DEPOT_GLN> listFromDb = await _igpsDepotGlnRepository.ReadContainersFromList(listToRead);
            listFromDb = listFromDb.Distinct().ToList();

            List<IGPS_DEPOT_LOCATION> listLocationFromDb =
                await _igpsDepotLocationRepository.ReadContainersFromList(glnList);
            listLocationFromDb = listLocationFromDb.Distinct().ToList();


            foreach (IGPS_DEPOT_GLN container in listFromDb)
            {
                listToDelete.Add(container.Gln);
            }

            foreach (IGPS_DEPOT_LOCATION container in listLocationFromDb)
            {
                listLocationToDelete.Add(container.Gln);
            }

            listLocationToDelete = listLocationToDelete.Distinct().ToList();
            stringToDelete = ConcatStringFromList(listToDelete);
            stringLocationToDelete = ConcatStringFromList(listLocationToDelete);

            _logger.Information(
                $"{stringLocationToDelete} containers with {listFromDb.Count} Grai(s) have been cleared and deleted");

            if (stringToDelete.Length > 0)
            {
                _igpsDepotGlnRepository.DeleteGlnsFromList(stringToDelete);
            }

            if (stringLocationToDelete.Length > 0)
            {
                _igpsDepotLocationRepository.DeleteContainersFromList(stringLocationToDelete);
            }
        }

        public async Task<List<string>> GetGhostGrais()
        {
            List<string> ghostGlns = await _igpsDepotGlnRepository.GetGhostGrais();

            //var ghostGlnsString = ConcatStringFromList(ghostGlns);
            //var ghostGrais = await _igpsDepotGlnRepository.ReadContainersFromList(ghostGlnsString);

            return ghostGlns;
        }

        public void ClearGrais(List<string> listOfGrais)
        {
            if (listOfGrais == null) return;

            var concatenatedList = ConcatStringFromList(listOfGrais);

            _igpsDepotGlnRepository.DeleteGraisFromList(concatenatedList);
        }

        public async Task<string> GetCountOfOrderId(string orderId)
        {
            return await _igpsDepotGlnRepository.ReadCountFromOrderId(orderId);
        }
        public async Task<string> GetCountOfGln(string gln)
        {
            return await _igpsDepotGlnRepository.ReadCountFromGln(gln);
        }
    }
}