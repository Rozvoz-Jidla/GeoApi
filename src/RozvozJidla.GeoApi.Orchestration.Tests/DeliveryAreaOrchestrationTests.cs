using System.Linq;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using NUnit.Framework;
using RozvozJidla.GeoApi.Common.Models;
using RozvozJidla.GeoApi.Common.Orchestrations;
using RozvozJidla.GeoApi.Common.Repository;
using RozvozJidla.GeoApi.Orchestration.Orchestrations;
using RozvozJidla.GeoApi.Orchestration.Repository;

namespace RozvozJidla.GeoApi.Orchestration.Tests
{
    public class DeliveryAreaOrchestrationTests
    {
        private IDeliveryAreaOrchestration _deliveryAreaOrchestration;

        [SetUp]
        public void Setup()
        {
            _deliveryAreaOrchestration = new DeliveryAreaOrchestration(
                new DeliveryAreaRepository(new TestConfigurationResolver()),
                new DeliveryProvidersCacheRepository(new TestConfigurationResolver()));
        }
        
        [Test]
        [Explicit]
        public void TestGetDeliveryAreaByLocation()
        {
            var deliveryAreaViewModels = _deliveryAreaOrchestration.GetDeliveryAreaByLocation(50.095772, 14.417304).GetAwaiter().GetResult();

            Assert.Greater(deliveryAreaViewModels.Count(), 0);
        }
    }
}