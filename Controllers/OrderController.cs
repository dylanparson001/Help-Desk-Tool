using iGPS_Help_Desk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Controllers
{
    public class OrderController : BaseController
    {
        public async Task<List<OrderRequestNewHeader>> GetBolsFromList(List<string> bolList)
        {
            var result = await _orderRequestNewHeaderRepository.GetOrdersFromList(bolList);

            return result;
        }

        public async Task RemoveSelectedOrders(List<string> orderList)
        {
            if (orderList.Count > 0)
                await _orderRequestNewHeaderRepository.RemoveOrders(orderList);
        }

        public async Task UpdateRequestedQuantity(int newQuantity, List<string> orderList)
        {
            if (newQuantity > 0 && orderList.Count > 0)
            {
                await _orderRequestNewHeaderRepository.UpdateRequestedQuantity(newQuantity, orderList);
            } 
        }
        
    }
}
