using System.Collections.Generic;
using System.Threading.Tasks;
using RozvozJidla.GeoApi.Common.Models;

namespace RozvozJidla.GeoApi.Common.Repository
{
    /// <summary>
    /// Database repository to return DeliveryArea
    /// </summary>
    public interface IDeliveryAreaRepository
    {
        Task SaveDeliveryProvider(DeliveryProvider deliveryProvider);

        Task SaveDeliveryArea(DeliveryArea deliveryArea);

        Task<IEnumerable<DeliveryArea>> GetDeliveryAreaByLocation(double longitude, double latitude);
    }
}