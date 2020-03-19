using MongoDB.Bson;

namespace RozvozJidla.GeoApi.Common.Models
{
    /// <summary>
    /// Provides info about Delivery provider company
    /// </summary>
    public class DeliveryProvider
    {
        /// <summary>
        /// MongoDb Id
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Delivery Provider Name - company
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Delivery Provider web site
        /// </summary>
        public string WebSite { get; set; }
    }
}