using iGPS_Help_Desk.Enums;
using iGPS_Help_Desk.Interfaces;
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
        private readonly IOrderRequestNewHeaderRepository _orderRequestNewHeaderRepository;

        public OrderController(IOrderRequestNewHeaderRepository orderRequestNewHeaderRepository)
        {
            _orderRequestNewHeaderRepository = orderRequestNewHeaderRepository;
        }
        public async Task<List<OrderRequestNewHeader>> GetBolsFromList(List<string> bolList)
        {
            var result = await _orderRequestNewHeaderRepository.GetOrdersFromList(bolList);

            return result;
        }

        public async Task RemoveSelectedOrders(List<string> orderList)
        {
            if (orderList.Count > 0)
                await _orderRequestNewHeaderRepository.SetOrderStatus(orderList, OrderStatus.Cancelled);
        }
        public async Task SetSelectedOrdersToOpen(List<string> orderList)
        {
            if (orderList.Count > 0)
                await _orderRequestNewHeaderRepository.SetOrderStatus(orderList, OrderStatus.Open);
        }

        public async Task UpdateRequestedQuantity(int newQuantity, List<string> orderList)
        {
            if (newQuantity > 0 && orderList.Count > 0)
            {
                await _orderRequestNewHeaderRepository.UpdateRequestedQuantity(newQuantity, orderList);
            }
        }
        public async Task<string> GetCountOfOrderId(string orderId)
        {
            return await _orderRequestNewHeaderRepository.ReadCountFromOrderId(orderId);
        }

        public async Task<List<string>> GetGraisFromOrderId(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                return null;
            }

            var result = await _orderRequestNewHeaderRepository.GetGraisFromOrderId(orderId);

            return result;
        }

        public async Task ClearExistingGrais(string graiString)
        {
            if (string.IsNullOrWhiteSpace(graiString))
            {
                return;
            }

            await _orderRequestNewHeaderRepository.ClearExistingGrais(graiString);

        }
    }
}
