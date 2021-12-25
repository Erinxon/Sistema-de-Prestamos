using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestamos.Api.Controllers;
using Prestamos.Api.AutoMapperConfig;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Implementations;
using Prestamos.Infrastructure.Interfaces;
using AutoMapper;

namespace Prestamos.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            
            // Arrange
            var context = new PrestamosDBContext();
            var unitOfWork = new UnitOfWork(context);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var controller = new EstatusController(unitOfWork, mapper);
            // Act
            var result = await controller.GetAll();
            // Assert
            Assert.AreEqual(200, result.Value.StatusCode);
        }
    }
}
