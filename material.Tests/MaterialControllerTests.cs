using System;
using System.Linq;
using System.Text;
using Material.Web.Models;
using System.Threading.Tasks;
using material.web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace material.Tests
{
    [TestFixture]
    public class MaterialControllerTests
    {
        private MaterialController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new MaterialController();
        }

        [Test]
        public void GetAll_ReturnsOkResult_WithListOfMaterials()
        {
            // Act nn
            var result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var materials = okResult.Value as IEnumerable<MaterialEntity>;
            Assert.IsNotNull(materials);
            Assert.AreEqual(2, materials.Count());
        }
        //[Test]
        //public void GetAll_ReturnsOkResult_WithListOfMaterials()
        //{
        //    // Act
        //    var result = _controller.GetAll();

        //    // Assert
        //    Assert.IsInstanceOf<OkObjectResult>(result.Result);

        //    var okResult = result.Result as OkObjectResult;
        //    Assert.IsNotNull(okResult);

        //    var materials = okResult.Value as IEnumerable<MaterialEntity>;
        //    Assert.IsNotNull(materials);
        //    Assert.AreEqual(2, materials.Count());
        //}

        [Test]
        public void GetAll_ReturnsMaterials_WithExpectedProperties()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var materials = okResult.Value as IEnumerable<MaterialEntity>;
            Assert.IsNotNull(materials);

            var materialList = materials.ToList();

            Assert.AreEqual(1, materialList[0].Id);
            Assert.AreEqual("Material 1", materialList[0].Name);
            Assert.AreEqual("Description for Material 1", materialList[0].Description);

            Assert.AreEqual(2, materialList[1].Id);
            Assert.AreEqual("Material 2", materialList[1].Name);
            Assert.AreEqual("Description for Material 2", materialList[1].Description);
        }
    }
}
