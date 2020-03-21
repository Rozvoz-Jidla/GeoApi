using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using RozvozJidla.GeoApi.Common.Configuration;
using RozvozJidla.GeoApi.Common.Models;

namespace RozvozJidla.GeoApi.Orchestration.Repository
{
    public class DeliveryProvidersCacheRepository : BaseMongoRepository, IDeliveryProvidersCache
    {
        public DeliveryProvidersCacheRepository(IConfigurationResolver<DatabaseConfiguration> databaseConfigurationResolver) : base(databaseConfigurationResolver)
        {
            var deliveryProviderCollection = _mongoDatabase.GetCollection<DeliveryProvider>(nameof(DeliveryProvider));
            Providers = deliveryProviderCollection.FindSync(deliveryProvider => true).ToList()
                .ToDictionary(deliveryProvider => deliveryProvider.Id, deliveryProvider => deliveryProvider);
        }

        public Dictionary<ObjectId, DeliveryProvider> Providers { get; private set; }
    }
}
