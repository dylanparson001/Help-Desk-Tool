using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Logger;
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
        private readonly ILogger _logger;
        private readonly IOrderRequestNewHeaderRepository _orderRequestNewHeaderRepository;

        public RollbackController(
            IOrderRequestNewHeaderRepository orderRequestNewHeaderRepository,
            ILoggerFactory loggerFactory
            )
        {
            _orderRequestNewHeaderRepository = orderRequestNewHeaderRepository;
            _logger = loggerFactory.CreateContextualLogger("Rollback");
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
            bool isSuccess = false;
            if (string.IsNullOrEmpty(orderId)) return;

            if (string.IsNullOrEmpty(gln)) return;

            try
            {
                if (firstAttempt)
                {
                    _logger.Information($"First attempt to rollback for order {orderId} into GLN {gln} has started...");

                    isSuccess = await _orderRequestNewHeaderRepository.RollbackInsertGrais(orderId, gln);
                    isSuccess = await _orderRequestNewHeaderRepository.RollbackUpdateProcessingStatus(orderId);
                    isSuccess = await _orderRequestNewHeaderRepository.RollbackDeleteGraisFromOrderId(orderId);

                    if (isSuccess)
                    {
                        _logger.Information($"First attempt to rollback for order {orderId} into GLN {gln} has been completed.");
                    }
                }
                else
                {
                    _logger.Information($"Second attempt to rollback for order {orderId} into GLN {gln} has started...");

                    isSuccess = await _orderRequestNewHeaderRepository.RollbackInsertGrais(orderId, gln);
                    isSuccess = await _orderRequestNewHeaderRepository.RollbackUpdateProcessingStatus(orderId);
                    isSuccess = await _orderRequestNewHeaderRepository.RollbackDeleteGraisFromOrderId(orderId);
                    
                    if (isSuccess)
                    {
                        _logger.Information("Second rollback attempt completed successfully after GRAIs were cleared");
                    }

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
