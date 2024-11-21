using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Controllers
{
    public class RollbackController : BaseController
    {
        public async Task<string> GetTrailerNumber(string orderId)
        {
            return await _orderRequestNewHeaderRepository.GetTrailerNumber(orderId);
        }

        public async Task<string> GetSealNumber(string orderId)
        {
            return await _orderRequestNewHeaderRepository.GetSealNumber(orderId);
        }
        public async Task Rollback(string orderId, string gln)
        {
            try
            {

                await _orderRequestNewHeaderRepository.Rollback(orderId, gln);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
