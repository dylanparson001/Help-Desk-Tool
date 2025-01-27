using iGPS_Help_Desk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Interfaces
{
    public interface IIgpsDepotLocationRepository
    {
        Task<List<IGPS_DEPOT_LOCATION>> ReadAllContainers();
        Task<List<IGPS_DEPOT_LOCATION>> ReadContainersFromList(List<string> list);
        Task<List<string>> ReadDnus();
        Task<List<IGPS_DEPOT_LOCATION>> ReadFromSearch(string search);
        void DeleteContainersFromList(string list);

    }
}
