using iGPS_Help_Desk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Interfaces
{
    public interface IOrderRequestNewHeaderRepository
    {
        Task<List<OrderRequestNewHeader>> GetOrdersFromList(List<string> bols);
        Task RemoveOrders(List<string> orderIds);
        Task UpdateRequestedQuantity(int newQuantity, List<string> orderIds);
        Task<string> GetTrailerNumber(string orderId);
        Task<string> GetSealNumber(string orderId);
        Task Rollback(string orderId, string gln);
        Task<List<string>> GetGraisFromOrderId(string orderId);
        Task ClearExistingGrais(string grais);
        Task<string> ReadCountFromOrderId(string gln);
        Task<bool> RollbackInsertGrais(string orderId, string gln);
        Task<bool> RollbackUpdateProcessingStatus(string orderId);
        Task<bool> RollbackDeleteGraisFromOrderId(string orderId);

    }
}
