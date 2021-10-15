using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OceanicAirlines.Domain.EntityModels;
using WebApplication1.Controllers;
using OceanicAirlines.Application.Repos;
using OceanicAirlines.Application.Services;
using OceanicAirlines.Infrastructue.Services;
using Moq;

namespace UnitTestProject1.ControllersTest
{
    [TestClass]
    public class GetByNametTest
    {
        public GetByNametTest()
        {
            cityService = new CityService(cityRepo.Object);
        }
        private Mock<ICityRepo> cityRepo = new Mock<ICityRepo>();

        public CityService cityService { get; }

        [TestMethod]
        public void CityGetSingleName()
        {
            cityRepo.Setup(p => p.GetSingleByName("tanger")).Returns(new City {Name = "tanger"});

            var result = cityService.GetSingleByName("tanger");

            Assert.AreEqual("tanger", result.Name);
        }
    }
}
