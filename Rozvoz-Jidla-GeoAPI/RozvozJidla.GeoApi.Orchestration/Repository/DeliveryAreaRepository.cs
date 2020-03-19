using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using RozvozJidla.GeoApi.Common.Configuration;
using RozvozJidla.GeoApi.Common.Models;
using RozvozJidla.GeoApi.Common.Repository;

namespace RozvozJidla.GeoApi.Orchestration.Repository
{
    public class DeliveryAreaRepository : BaseMongoRepository, IDeliveryAreaRepository
    {
        private readonly IMongoCollection<DeliveryArea> _deliveryAreaCollection;
        private readonly IMongoCollection<DeliveryProvider> _deliveryProviderCollection;

        public DeliveryAreaRepository(IConfigurationResolver<DatabaseConfiguration> databaseConfigurationResolver) : base(databaseConfigurationResolver)
        {
            _deliveryAreaCollection = _mongoDatabase.GetCollection<DeliveryArea>(nameof(DeliveryArea));
            _deliveryProviderCollection = _mongoDatabase.GetCollection<DeliveryProvider>(nameof(DeliveryProvider));
        }

        public async Task SaveDeliveryProvider(DeliveryProvider deliveryProvider)
        {
            await _deliveryProviderCollection.InsertOneAsync(deliveryProvider);
        }

        public async Task SaveDeliveryArea(DeliveryArea deliveryArea)
        {
            await _deliveryAreaCollection.InsertOneAsync(deliveryArea);
        }

        public async Task<IEnumerable<DeliveryArea>> GetDeliveryAreaByLocation(double longitude, double latitude)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<DeliveryArea>.Filter.GeoIntersects(deliveryArea => deliveryArea.Polygon, GeoJson.Point(new GeoJson2DGeographicCoordinates(longitude, latitude)));
            var asyncCursor = await _deliveryAreaCollection.FindAsync(filter);
            return await asyncCursor.ToListAsync();
        }
    }
}
