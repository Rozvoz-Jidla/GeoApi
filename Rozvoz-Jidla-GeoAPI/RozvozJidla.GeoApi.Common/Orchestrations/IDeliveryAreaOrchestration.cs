using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RozvozJidla.GeoApi.Common.Models.ViewModels;

namespace RozvozJidla.GeoApi.Common.Orchestrations
{
    public interface IDeliveryAreaOrchestration
    {
        /// <summary>
        /// Returns FE ViewModel for DeliveryAreaByLocation based on provided GPS coordinates
        /// </summary>
        /// <param name="longitude">GPS longitude, like 50.095772</param>
        /// <param name="latitude">GPS latitude, like 14.417304</param>
        /// <returns>FE ViewModel of matched delivery areas</returns>
        Task<IEnumerable<DeliveryAreaViewModel>> GetDeliveryAreaByLocation(double longitude, double latitude);
    }
}