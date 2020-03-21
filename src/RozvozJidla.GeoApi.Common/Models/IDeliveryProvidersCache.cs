using System.Collections.Generic;
using MongoDB.Bson;

namespace RozvozJidla.GeoApi.Common.Models
{
    public interface IDeliveryProvidersCache
    {
        /// <summary>
        /// Provides Cache of Delivery Providers from MongoDb
        /// </summary>
        Dictionary<ObjectId, DeliveryProvider> Providers { get; }
    }
}
