using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace RozvozJidla.GeoApi.Common.Models
{
    public class DeliveryArea
    {
        /// <summary>
        /// MongoDb Id
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// MongoDb Related Delivery Provider Id
        /// </summary>
        public ObjectId DeliveryProviderId { get; set; }

        /// <summary>
        /// Name of Polygon - delivery area, like area in city
        /// </summary>
        public string PolygonName { get; set; }

        /// <summary>
        /// Defines GPS coordinates of delivery area
        /// </summary>
        /// <example></example>
        public GeoJsonPolygon<GeoJson2DGeographicCoordinates> Polygon { get; set; }
    }
}