using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RozvozJidla.GeoApi.Common.Models;
using RozvozJidla.GeoApi.Common.Models.ViewModels;
using RozvozJidla.GeoApi.Common.Orchestrations;
using RozvozJidla.GeoApi.Common.Repository;

namespace RozvozJidla.GeoApi.Orchestration.Orchestrations
{
    public class DeliveryAreaOrchestration : IDeliveryAreaOrchestration
    {
        private readonly IDeliveryAreaRepository _deliveryAreaRepository;
        private readonly IDeliveryProvidersCache _devDeliveryProvidersCache;

        public DeliveryAreaOrchestration(IDeliveryAreaRepository deliveryAreaRepository, IDeliveryProvidersCache devDeliveryProvidersCache)
        {
            _deliveryAreaRepository = deliveryAreaRepository;
            _devDeliveryProvidersCache = devDeliveryProvidersCache;
        }

        public async Task<IEnumerable<DeliveryAreaViewModel>> GetDeliveryAreaByLocation(double longitude, double latitude)
        {
            return (await _deliveryAreaRepository.GetDeliveryAreaByLocation(longitude, latitude)).Select(deliveryArea =>
                new DeliveryAreaViewModel()
                {
                    DeliveryProviderName = _devDeliveryProvidersCache.Providers[deliveryArea.DeliveryProviderId].Name,
                    DeliveryProviderWebSite =
                        _devDeliveryProvidersCache.Providers[deliveryArea.DeliveryProviderId].WebSite,
                    DeliveryAreaName = deliveryArea.PolygonName
                });
        }
    }
}