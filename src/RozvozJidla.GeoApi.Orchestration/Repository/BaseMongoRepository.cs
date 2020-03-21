using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using MongoDB.Driver;
using RozvozJidla.GeoApi.Common.Configuration;

namespace RozvozJidla.GeoApi.Orchestration.Repository
{
    public class BaseMongoRepository
    {
        protected IMongoDatabase _mongoDatabase;

        public BaseMongoRepository(IConfigurationResolver<DatabaseConfiguration> configurationResolver)
        {
            var databaseConfiguration = configurationResolver.GetConfig();
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(databaseConfiguration.ConnectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            _mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.DatabaseName);
        }
    }
}