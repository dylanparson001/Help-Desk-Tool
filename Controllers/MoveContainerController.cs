using System;
using iGPS_Help_Desk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace iGPS_Help_Desk.Controllers
{
    public class MoveContainerController : BaseController
    {
        private readonly ILogger _logger = Log.ForContext("ClearContainer", true);
        public async Task<List<IGPS_DEPOT_LOCATION>> ReadAllContainers()
        {
            var result = await _igpsDepotLocationRepository.ReadAllContainers();

            return result;
        }


        public async Task<List<IGPS_DEPOT_GLN>> ReadGraisFromContainer(string gln)
        {
            var listResult = new List<string>
            {
                gln
            };
            var temp = ConcatStringFromList(listResult);

            var result = await _igpsDepotGlnRepository.ReadContainersFromListOrderByDate(temp);

            return result;

        }

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadContainersFromSearch(string search)
        {
            var listResult = new List<IGPS_DEPOT_LOCATION>();
            try
            {
                listResult = await _igpsDepotLocationRepository.ReadFromSearch(search);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return listResult;
        }

        public async Task<List<IGPS_DEPOT_GLN>> SearchGraiFromContainer(string grai, string gln, string generationPrefix)
        {
            var listResult = new List<IGPS_DEPOT_GLN>();

            try
            {
                listResult = await _igpsDepotGlnRepository.SearchGraiFromContainer(grai, gln, generationPrefix);
            } 
            catch (Exception ex)
            {
                _logger.Error(ex.Message);

            }
            return listResult;
        }

    }
}
