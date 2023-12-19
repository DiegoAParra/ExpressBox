using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageDelivery.Application.Contracts.DTO.Core;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.GUI.Controllers;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PackageDelivery.Test.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Route_Post_ReturnsView()
        {
            // Arrange
            // Mock de las dependencias
            var mockWarehouseApplication = new Mock<Application.Contracts.Interfaces.Parameters.IWarehouseApplication>();
            var mockPackageHistoryApplication = new Mock<Application.Contracts.Interfaces.Core.IPackageHistoryApplication>();
            var mockDeliveryApplication = new Mock<Application.Contracts.Interfaces.Parameters.IDeliveryApplication>();
            var mockAddressApplication = new Mock<Application.Contracts.Interfaces.Parameters.IAddressApplication>();
            var mockCityApplication = new Mock<Application.Contracts.Interfaces.Parameters.ICityApplication>();
            var mockDepartmentApplication = new Mock<Application.Contracts.Interfaces.Parameters.IDepartmentApplication>();

            // Setup mock data
            var warehouseDTOs = new List<WarehouseDTO>
            {
                new WarehouseDTO { Id = 1, Name = "Warehouse 1" },
                new WarehouseDTO { Id = 2, Name = "Warehouse 2" },
                new WarehouseDTO { Id = 3, Name = "Warehouse 3" }
            };

            var packageHistoryDTOs = new List<PackageHistoryDTO>
            {
                new PackageHistoryDTO { Id = 1, Id_Warehouse = 1, Id_Package = 1, DepurateDate = DateTime.Now.Date, Description = "PC Gamer" },
                new PackageHistoryDTO { Id = 2, Id_Warehouse = 1, Id_Package = 2, DepurateDate = DateTime.Now.AddDays(-1), Description = "Bolso" }, // Paquete con fecha de entrega un día anterior
                new PackageHistoryDTO { Id = 3, Id_Warehouse = 1, Id_Package = 3, DepurateDate = DateTime.Now.Date, Description = "Mesa" },
                new PackageHistoryDTO { Id = 4, Id_Warehouse = 2, Id_Package = 4, DepurateDate = DateTime.Now.Date, Description = "Papeleria" } // Paquete de otra bodega
            };

            var deliveryDTOs = new List<DeliveryDTO>
            {
                new DeliveryDTO { Id = 1, Id_Package = 1, Id_DestinationAddress = 1 },
                new DeliveryDTO { Id = 2, Id_Package = 2, Id_DestinationAddress = 2 },
                new DeliveryDTO { Id = 3, Id_Package = 3, Id_DestinationAddress = 3 },
                new DeliveryDTO { Id = 4, Id_Package = 4, Id_DestinationAddress = 4 }
            };

            var addressDTOs = new List<AddressDTO>
            {
                new AddressDTO { Id = 1, Id_City = 1, StreetType = "Cll 66", Number = "30-26", Neighborhood = "Fatima" },
                new AddressDTO { Id = 2, Id_City = 1, StreetType = "Cra 23", Number = "26A", Neighborhood = "Centro" },
                new AddressDTO { Id = 3, Id_City = 1, StreetType = "Calle 70", Number = "56-16", Neighborhood = "La Camelia" },
                new AddressDTO { Id = 4, Id_City = 1, StreetType = "Cra 2A", Number = "61", Neighborhood = "Palermo" }
            };

            var cityDTOs = new List<CityDTO>
            {
                new CityDTO { Id = 1, Name = "Manizales", Id_Department = 1 },
                new CityDTO { Id = 2, Name = "Ibagué", Id_Department = 2 }
            };

            var departmentDTOs = new List<DepartmentDTO>
            {
                new DepartmentDTO { Id = 1, Name = "Caldas" },
                new DepartmentDTO { Id = 2, Name = "Tolima" }
            };

            // Setup mock behavior
            mockWarehouseApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(warehouseDTOs);
            mockPackageHistoryApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(packageHistoryDTOs);
            mockDeliveryApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(deliveryDTOs);
            mockAddressApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(addressDTOs);
            mockCityApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(cityDTOs);
            mockDepartmentApplication.Setup(m => m.getRecordList(It.IsAny<string>())).Returns(departmentDTOs);

            // Crea una instancia del controlador con las dependencias mockeadas
            var controller = new HomeController(
                mockWarehouseApplication.Object,
                mockPackageHistoryApplication.Object,
                mockDeliveryApplication.Object,
                mockAddressApplication.Object,
                mockCityApplication.Object,
                mockDepartmentApplication.Object
            );

            // Act
            var result = controller.Route("1", DateTime.Now) as ViewResult;

            //Lista de ruta que se espera
            IEnumerable<RouteModel> listRoute = new List<RouteModel>();
            RouteModel routeElement1 = new RouteModel { Id_Package = 1, Description = "PC Gamer", DestinationAddress = "Cll 66 Nro 30-26 Barrio Fatima Manizales, Caldas", DepurateDate = DateTime.Now.Date };
            RouteModel routeElement2 = new RouteModel { Id_Package = 3, Description = "Mesa", DestinationAddress = "Calle 70 Nro 56-16 Barrio La Camelia Manizales, Caldas", DepurateDate = DateTime.Now.Date };
            List<RouteModel> listaModificable = listRoute.ToList();
            listaModificable.Add(routeElement1);
            listaModificable.Add(routeElement2);
            listRoute = listaModificable;

            // Assert
            // Verifica que el resultado no sea nulo
            Assert.IsNotNull(result);

            // Verifica que el modelo de la vista sea del tipo Tuple<IEnumerable<WarehouseModel>, IEnumerable<RouteModel>>
            Assert.IsInstanceOfType(result.Model, typeof(Tuple<IEnumerable<WarehouseModel>, IEnumerable<RouteModel>>));

            // Obtiene la tupla del modelo de la vista
            var tuplaResult = (Tuple<IEnumerable<WarehouseModel>, IEnumerable<RouteModel>>)result.Model;

            // Assert que tengan la misma cantidad de elementos
            Assert.AreEqual(tuplaResult.Item2.Count(), listRoute.Count());

            // Assert que los elementos de las listas sean iguales
            for (int i = 0; i < listRoute.Count(); i++)
            {
                Assert.AreEqual(tuplaResult.Item2.ToList()[i].Id_Package, listRoute.ToList()[i].Id_Package);
                Assert.AreEqual(tuplaResult.Item2.ToList()[i].Description, listRoute.ToList()[i].Description);
                Assert.AreEqual(tuplaResult.Item2.ToList()[i].DestinationAddress, listRoute.ToList()[i].DestinationAddress);
                Assert.AreEqual(tuplaResult.Item2.ToList()[i].DepurateDate, listRoute.ToList()[i].DepurateDate);
            }
        }
    }
}
