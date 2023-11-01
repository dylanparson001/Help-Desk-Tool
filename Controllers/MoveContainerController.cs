using System;
using iGPS_Help_Desk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Controllers
{
    public class MoveContainerController : BaseController
    {
        public async Task<List<IGPS_DEPOT_LOCATION>> ReadAllContainers()
        {
            var result = await _igpsDepotLocationRepository.ReadAllContainers();

            return result;
        }


        public async Task<int> GetCountOfContainer(string gln)
        {
            var listResult = new List<string>
            {
                gln
            };

            var temp = ConcatStringFromList(listResult);
            var containers = await _igpsDepotGlnRepository.ReadContainersFromList(temp);

            return  containers.Count;
        }

        public void MoveContainers(string fromGln, string toGln, int fromCount)
        {
            if (fromCount.Equals(0)) return;

            fromGln = $"'{fromGln}'";
            toGln = $"'{toGln}'";
            
            _igpsDepotGlnRepository.UpdateContainersToExistingContainer(fromGln, toGln);
            
        }

        public void DeleteContainer(string glnToDelete)
        {
            glnToDelete = $"'{glnToDelete}'";
            
            _igpsDepotLocationRepository.DeleteContainersFromList(glnToDelete);
        }

        public void MoveSelectedGraisToContainer(List<string> grais, string toGln)
        {
            if (grais != null && toGln != null)
            {
                _igpsDepotGlnRepository.UpdateSelectedGrais(grais, toGln);
            }
        }

        public async Task<List<IGPS_DEPOT_GLN>> ReadGraisFromContainer(string gln)
        {
            var listResult = new List<string>
            {
                gln
            };
            var temp = ConcatStringFromList(listResult);

            var result = await _igpsDepotGlnRepository.ReadContainersFromList(temp);

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
                Console.WriteLine(ex);
            }

            return listResult;
        }

    }
}
