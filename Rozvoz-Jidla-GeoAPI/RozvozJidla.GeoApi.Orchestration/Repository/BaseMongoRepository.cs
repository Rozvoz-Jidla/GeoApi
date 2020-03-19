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
            //string connectionString = @"mongodb://rozvoz-jidla-db:7ANtrWFsZ5DnXHULL73iecMz8tjSO4TtvvgJ8IhceI0nWYH7wh2yKhJTuHQiScbefVRfmpZTAhBLCG42w7qYaw==@rozvoz-jidla-db.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@rozvoz-jidla-db@&retrywrites=false";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(databaseConfiguration.ConnectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            _mongoDatabase = mongoClient.GetDatabase(databaseConfiguration.DatabaseName);
        }
    }
}