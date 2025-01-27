using iGPS_Help_Desk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Interfaces
{
    public interface IIgpsDepotGlnRepository
    {
        Task<List<IGPS_DEPOT_GLN>> SearchGraiFromContainer(string grai, string gln, string generationPrefix);
        Task<(List<IGPS_DEPOT_GLN>, int)> ReadAllContainersBatch();
        Task<int> GetCountOfTable();
        Task<List<IGPS_DEPOT_GLN>> ReadFromGraiList(List<string> list);
        Task<List<IGPS_DEPOT_GLN>> ReadContainersFromList(string list);
        Task<string> GetSiteID();
        Task<List<IGPS_DEPOT_GLN>> ReadContainersFromListOrderByDate(string list);
        Task<string> ReadCountFromGln(string gln);
        void DeleteGlnsFromList(string list);
        Task<List<string>> GetGhostGrais();
        void DeleteGraisFromList(string list);
    }
}
