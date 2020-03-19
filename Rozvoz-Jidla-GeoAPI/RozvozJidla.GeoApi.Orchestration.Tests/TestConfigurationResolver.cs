using System;
using RozvozJidla.GeoApi.Common.Configuration;

namespace RozvozJidla.GeoApi.Orchestration.Tests
{
    public class TestConfigurationResolver : IConfigurationResolver<DatabaseConfiguration>
    {
        public DatabaseConfiguration GetConfig()
        {
            return new DatabaseConfiguration()
            {
                DatabaseName = "DATABASE_NAME",
                ConnectionString = "CONNECTION_STRING"
            };
        }
    }
}
