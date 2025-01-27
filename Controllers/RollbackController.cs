using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Repositories;
using Serilog;
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
        private readonly ILogger _logger = Log.ForContext("Rollback", true);
        private readonly IOrderRequestNewHeaderRepository _orderRequestNewHeaderRepository;

        public RollbackController(IOrderRequestNewHeaderRepository orderRequestNewHeaderRepository)
        {
            _orderRequestNewHeaderRepository = orderRequestNewHeaderRepository;
        }
        public async Task<string> GetTrailerNumber(string orderId)
        {
            
            return await _orderRequestNewHeaderRepository.GetTrailerNumber(orderId);
        }

        public async Task<string> GetSealNumber(string orderId)
        {
            return await _orderRequestNewHeaderRepository.GetSealNumber(orderId);
        }
        public async Task Rollback(string orderId, string gln, bool firstAttempt)
        {
            try
            {
                if (firstAttempt)
                {
                    _logger.Information($"First attempt to rollback for order {orderId} into GLN {gln} has started...");
                    await _orderRequestNewHeaderRepository.Rollback(orderId, gln);
                    _logger.Information($"First attempt to rollback for order {orderId} into GLN {gln} has been completed.");
                }
                else
                {
                    _logger.Information($"Second attempt to rollback for order {orderId} into GLN {gln} has started...");

                    await _orderRequestNewHeaderRepository.Rollback(orderId, gln);

                    _logger.Information("Second rollback attempt completed successfully after GRAIs were cleared");

                }

            }

            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

    }
}
