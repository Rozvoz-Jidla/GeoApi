using System;
using Microsoft.Extensions.Configuration;
using RozvozJidla.GeoApi.Common.Configuration;

namespace RozvozJidla.GeoApi.WebAPI.Configuration
{
    public class ConfigurationResolver<T> : IConfigurationResolver<T> where T : class
    {
        private const string CONFIG_FILE_NAME = "config.json";

        public T GetConfig()
        {
            ConfigurationBuilder configurationBuilder =
                new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(CONFIG_FILE_NAME, true);

            var cofigurationRoot = configurationBuilder.Build();
            var configurationInstance = Activator.CreateInstance<T>();
            cofigurationRoot.GetSection(typeof(T).Name).Bind(configurationInstance);
            return configurationInstance;
        }
    }
}
