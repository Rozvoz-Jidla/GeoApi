namespace RozvozJidla.GeoApi.Common.Configuration
{
    public class DatabaseConfiguration
    {
        /// <summary>
        /// Connection string to MongoDB
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Name of MongoDb Collection
        /// </summary>
        public string DatabaseName { get; set; }
    }
}
