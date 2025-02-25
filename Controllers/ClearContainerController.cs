using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Logger;
using iGPS_Help_Desk.Models;
using Serilog;

namespace iGPS_Help_Desk.Controllers
{
    public class ClearContainerController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IIgpsDepotGlnRepository _igpsDepotGlnRepository;
        private readonly IIgpsDepotLocationRepository _igpsDepotLocationRepository;

        public ClearContainerController(IIgpsDepotGlnRepository igpsDepotGlnRepository, 
            IIgpsDepotLocationRepository igpsDepotLocationRepository,
            ILoggerFactory loggerFactory
            )
        {
            _igpsDepotGlnRepository = igpsDepotGlnRepository;
            _igpsDepotLocationRepository = igpsDepotLocationRepository;
            _logger = loggerFactory.CreateContextualLogger("ClearContainer");
        }

        public async Task<(List<IGPS_DEPOT_GLN>, List<IGPS_DEPOT_LOCATION>)> GetDnus()
        {
            // Get List of dnus
            
            List<string> dnuList = await _igpsDepotLocationRepository.ReadDnus();

            // concat '', to items in list
            string stringGlns = ConcatStringFromList(dnuList);

            //  Get the containers from IGPS_DEPOT_GLN table
            List<IGPS_DEPOT_GLN> glnList = await _igpsDepotGlnRepository.ReadContainersFromList(stringGlns); ;

            List<IGPS_DEPOT_LOCATION> locationList =
                await _igpsDepotLocationRepository.ReadContainersFromList(dnuList);


            return (glnList.OrderBy(x => x.Gln).ToList(), locationList.OrderBy(x => x.Gln).ToList());
        }

        /// <summary>
        /// Retreives List of IGPS_DEPOT_GLN data (AKA GRAIs)
        /// </summary>
        /// <param name="containerList"></param>
        /// <returns></returns>
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


            result = await _igpsDepotLocationRepository.ReadContainersFromList(containerList);
            return result;
        }

        public async Task<(List<IGPS_DEPOT_GLN>, int)> GetAllContainers()
        {
            var result = await _igpsDepotGlnRepository.ReadAllContainersBatch();
            return result;
        }

        /// <summary>
        /// Clears containers and associated in GRAIs in the IGPS_DEPOT_LOCATION and IGPS_DEPOT_GLN table respectively
        /// </summary>
        /// <param name="glnList"></param>
        public async Task ClearContainers(List<string> glnList, bool deleteGraisOnly = false)
        {
            if (glnList == null)
            {
                return;
            }
            if (glnList.Count == 0)
            {
                return;

            }

            // Retrieves count of GRAIs
            int count = await _igpsDepotGlnRepository.GetCountOfTable();

            List<string> listToDelete = new List<string>();
            List<string> listLocationToDelete = new List<string>();

            string stringToDelete;
            string stringLocationToDelete;
            if (glnList == null) return;


            string listToRead = ConcatStringFromList(glnList);

            // List from db
            List<IGPS_DEPOT_GLN> listFromDb = await _igpsDepotGlnRepository
                .ReadContainersFromList(listToRead);


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


            if (stringToDelete.Length > 0)
            {
                _igpsDepotGlnRepository.DeleteGlnsFromList(stringToDelete);
                _logger.Information($"{listFromDb.Count} Grai(s) have been deleted");

            }

            if (stringLocationToDelete.Length > 0 && !deleteGraisOnly)
            {
                _igpsDepotLocationRepository.DeleteContainersFromList(stringLocationToDelete);
                _logger.Information($"{listLocationToDelete.Count} containers have been cleared and deleted");

            }

        }

        public async Task<List<string>> GetGhostGrais()
        {
            List<string> ghostGlns = await _igpsDepotGlnRepository.GetGhostGrais();

            return ghostGlns;
        }

        public void ClearGrais(List<string> listOfGrais)
        {
            if (listOfGrais == null || listOfGrais.Count == 0) return;

            var concatenatedList = ConcatStringFromList(listOfGrais);

            try
            {

                _igpsDepotGlnRepository.DeleteGraisFromList(concatenatedList);
                _logger.Information($"{listOfGrais.Count} grais have been cleared");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }


        public async Task<string> GetCountOfGln(string gln)
        {
            return await _igpsDepotGlnRepository.ReadCountFromGln(gln);
        }
    }
}