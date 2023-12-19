using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PackageDelivery.Application.Contracts.DTO.Parameters;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Controllers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PackageDelivery.Test.Controllers
{
    [TestClass]
    public class PackageControllerTest
    {
        [TestMethod]
        public void Create_Post_ReturnsView()
        {
            // Arrange
            var mockPackageApplication = new Mock<IPackageApplication>();
            var mockOfficeApplication = new Mock<IOfficeApplication>();

            // Setup mock data
            var packageModel = new PackageModel
            {
                Id = 1,
                Weight = 5,
                Depth = 10,
                Width = 8,
                Height = 15,
                Id_Office = 1,
                OfficeName = "Office 1",
                OfficeList = new List<OfficeModel>
                {
                    new OfficeModel { Id = 1, Name = "Office 1" },
                    new OfficeModel { Id = 2, Name = "Office 2" },
                    new OfficeModel { Id = 3, Name = "Office 3" }
                }
            };

            var packageDTO = new PackageDTO
            {
                Id = 1,
                Weight = 5,
                Depth = 10,
                Width = 8,
                Height = 15,
                Id_Office = 1
            };

            mockPackageApplication.Setup(m => m.createRecord(It.IsAny<PackageDTO>())).Returns(packageDTO);

            var controller = new PackageController(mockPackageApplication.Object, mockOfficeApplication.Object);

            // Act
            var result = controller.Create(packageModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_Post_ReturnsView()
        {
            // Arrange
            var mockPackageApplication = new Mock<IPackageApplication>();
            var mockOfficeApplication = new Mock<IOfficeApplication>();

            // Setup mock data
            var packageId = 1;

            var packageModel = new PackageModel
            {
                Id = 1,
                Weight = 5,
                Depth = 10,
                Width = 8,
                Height = 15,
                Id_Office = 1,
                OfficeName = "Office 1",
                OfficeList = new List<OfficeModel>
                {
                    new OfficeModel { Id = 1, Name = "Office 1" },
                    new OfficeModel { Id = 2, Name = "Office 2" },
                    new OfficeModel { Id = 3, Name = "Office 3" }
                }
            };

            var packageDTO = new PackageDTO
            {
                Id = 1,
                Weight = 5,
                Depth = 10,
                Width = 8,
                Height = 15,
                Id_Office = 1
            };

            mockPackageApplication.Setup(m => m.getRecordById(packageId)).Returns(packageDTO);

            var controller = new PackageController(mockPackageApplication.Object, mockOfficeApplication.Object);

            // Act
            var result = controller.Edit(packageId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Edit", result.ViewName);

            // Verifica que el modelo de la vista sea del tipo PackageModel
            Assert.IsInstanceOfType(result.Model, typeof(PackageModel));

            // Convierte el modelo de la vista a PackageModel
            var actualModel = result.Model as PackageModel;

            // Verifica las propiedades del modelo
            Assert.AreEqual(packageModel.Id, actualModel.Id);
            Assert.AreEqual(packageModel.Weight, actualModel.Weight);
            Assert.AreEqual(packageModel.Depth, actualModel.Depth);
            Assert.AreEqual(packageModel.Width, actualModel.Width);
            Assert.AreEqual(packageModel.Height, actualModel.Height);
            Assert.AreEqual(packageModel.Id_Office, actualModel.Id_Office);
        }

        [TestMethod]
        public void DeleteConfirmed_Post_ReturnsView()
        {
            // Arrange
            var mockPackageApplication = new Mock<IPackageApplication>();
            var mockOfficeApplication = new Mock<IOfficeApplication>();

            // Setup mock data
            var packageId = 1;
            mockPackageApplication.Setup(m => m.deleteRecordById(packageId)).Returns(true);

            var controller = new PackageController(mockPackageApplication.Object, mockOfficeApplication.Object);

            // Act
            var result = controller.DeleteConfirmed(packageId) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
