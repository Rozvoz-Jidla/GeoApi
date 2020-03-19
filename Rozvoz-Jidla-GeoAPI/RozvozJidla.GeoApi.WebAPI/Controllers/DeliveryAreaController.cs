using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RozvozJidla.GeoApi.Common.Models.ViewModels;
using RozvozJidla.GeoApi.Common.Orchestrations;

namespace RozvozJidla.GeoApi.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryAreaController : ControllerBase
    {
        private readonly IDeliveryAreaOrchestration _deliveryAreaOrchestration;
        private readonly ILogger<DeliveryAreaController> _logger;

        public DeliveryAreaController(ILogger<DeliveryAreaController> logger, IDeliveryAreaOrchestration deliveryAreaOrchestration)
        {
            _logger = logger;
            _deliveryAreaOrchestration = deliveryAreaOrchestration;
        }

        [HttpPost]
        public async Task<IEnumerable<DeliveryAreaViewModel>> Get(double longitude, double latitude)
        {
            return await _deliveryAreaOrchestration.GetDeliveryAreaByLocation(longitude, latitude);
        }
    }
}