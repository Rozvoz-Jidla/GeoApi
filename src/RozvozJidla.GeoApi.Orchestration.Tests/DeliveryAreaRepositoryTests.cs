using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using NUnit.Framework;
using RozvozJidla.GeoApi.Common.Models;
using RozvozJidla.GeoApi.Orchestration.Repository;

namespace RozvozJidla.GeoApi.Orchestration.Tests
{
    public class DeliveryAreaRepositoryTests
    {
        private DeliveryAreaRepository _deliveryAreaRepository;

        [SetUp]
        public void Setup()
        {
            _deliveryAreaRepository = new DeliveryAreaRepository(new TestConfigurationResolver());
        }

        [Test]
        [Explicit]
        public void TestFillTestData()
        {
            var deliveryProvider1 = new DeliveryProvider() { Name = "Test Provider 1", WebSite = "www.test1.cz" };
            _deliveryAreaRepository.SaveDeliveryProvider(deliveryProvider1).GetAwaiter().GetResult();
            var deliveryProvider2 = new DeliveryProvider() { Name = "Test Provider 2", WebSite = "www.test2.cz" };
            _deliveryAreaRepository.SaveDeliveryProvider(deliveryProvider2).GetAwaiter().GetResult();


            IndexKeysDefinition<DeliveryArea> keyLocationY = "{ Polygon: '2dsphere' }";
            var locationIndexModelY = new CreateIndexModel<DeliveryArea>(keyLocationY);

            GeoJson2DGeographicCoordinates oneY = new GeoJson2DGeographicCoordinates(50.094166, 14.439476);
            GeoJson2DGeographicCoordinates twoY = new GeoJson2DGeographicCoordinates(50.093726, 14.407547);
            GeoJson2DGeographicCoordinates threeY = new GeoJson2DGeographicCoordinates(50.10716, 14.400681);
            GeoJson2DGeographicCoordinates fourY = new GeoJson2DGeographicCoordinates(50.112224, 14.431237);
            GeoJson2DGeographicCoordinates fiveY = new GeoJson2DGeographicCoordinates(50.105178, 14.44497);
            GeoJson2DGeographicCoordinates sixY = new GeoJson2DGeographicCoordinates(50.094166, 14.439476);

            GeoJson2DGeographicCoordinates[] coord_arrayY = new GeoJson2DGeographicCoordinates[]
                {oneY, twoY, threeY, fourY, fiveY, sixY};


            _deliveryAreaRepository.SaveDeliveryArea(new DeliveryArea()
            {
                PolygonName = "Praha Within 2",
                Polygon = GeoJson.Polygon(coord_arrayY),
                DeliveryProviderId = deliveryProvider1.Id

            }).GetAwaiter().GetResult();


            IndexKeysDefinition<DeliveryArea> keyLocation = "{ Polygon: '2dsphere' }";
            var locationIndexModel = new CreateIndexModel<DeliveryArea>(keyLocation);

            GeoJson2DGeographicCoordinates one = new GeoJson2DGeographicCoordinates(50.049057, 14.42282);
            GeoJson2DGeographicCoordinates two = new GeoJson2DGeographicCoordinates(50.067793, 14.500068);
            GeoJson2DGeographicCoordinates three = new GeoJson2DGeographicCoordinates(50.128797, 14.442733);
            GeoJson2DGeographicCoordinates four = new GeoJson2DGeographicCoordinates(50.10392, 14.385741);
            GeoJson2DGeographicCoordinates five = new GeoJson2DGeographicCoordinates(50.086741, 14.413894);
            GeoJson2DGeographicCoordinates six = new GeoJson2DGeographicCoordinates(50.049057, 14.42282);

            GeoJson2DGeographicCoordinates[] coord_array = new GeoJson2DGeographicCoordinates[]
                {one, two, three, four, five, six};


            _deliveryAreaRepository.SaveDeliveryArea(new DeliveryArea()
            {
                PolygonName = "Praha Within 1",
                Polygon = GeoJson.Polygon(coord_array),
                DeliveryProviderId = deliveryProvider2.Id

            }).GetAwaiter().GetResult();

            IndexKeysDefinition<DeliveryArea> keyLocation1 = "{ Polygon: '2dsphere' }";
            var locationIndexModel1 = new CreateIndexModel<DeliveryArea>(keyLocation);

            GeoJson2DGeographicCoordinates xone = new GeoJson2DGeographicCoordinates(50.102976, 14.383515);
            GeoJson2DGeographicCoordinates xtwo = new GeoJson2DGeographicCoordinates(50.07478, 14.427804);
            GeoJson2DGeographicCoordinates xthree = new GeoJson2DGeographicCoordinates(50.043482, 14.425744);
            GeoJson2DGeographicCoordinates xfour = new GeoJson2DGeographicCoordinates(50.039293, 14.379738);
            GeoJson2DGeographicCoordinates xfive = new GeoJson2DGeographicCoordinates(50.070594, 14.342659);
            GeoJson2DGeographicCoordinates xsix = new GeoJson2DGeographicCoordinates(50.102976, 14.383515);

            GeoJson2DGeographicCoordinates[] xcoord_array = new GeoJson2DGeographicCoordinates[]
                {xone, xtwo, xthree, xfour, xfive, xsix};


            _deliveryAreaRepository.SaveDeliveryArea(new DeliveryArea()
            {
                PolygonName = "Praha Outside 1",
                Polygon = GeoJson.Polygon(xcoord_array),
                DeliveryProviderId = deliveryProvider1.Id

            }).GetAwaiter().GetResult();
        }

        [Test]
        public void TestGetDeliveryAreaByLocation()
        {
            var deliveryAreas = _deliveryAreaRepository.GetDeliveryAreaByLocation(50.095772, 14.417304).GetAwaiter().GetResult();

            Assert.Greater(deliveryAreas.Count(), 0);
        }

    }
}