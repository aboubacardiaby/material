using System;
using System.Linq;
using NUnit.Framework;
using Material.Web.Models;
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
            // Act  
            var result = _controller.GetAll();

            // Assert  
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());

            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);

            var materials = okResult.Value as IEnumerable<MaterialEntity>;
            Assert.That(materials, Is.Not.Null);
            Assert.That(materials.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAll_ReturnsMaterials_WithExpectedProperties()
        {
            // Act  
            var result = _controller.GetAll();

            // Assert  
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);

            var materials = okResult.Value as IEnumerable<MaterialEntity>;
            Assert.That(materials, Is.Not.Null);

            var materialList = materials.ToList();

            Assert.That(materialList[0].Id, Is.EqualTo(1));
            Assert.That(materialList[0].Name, Is.EqualTo("Material 1"));
            Assert.That(materialList[0].Description, Is.EqualTo("Description for Material 1"));

            Assert.That(materialList[1].Id, Is.EqualTo(2));
            Assert.That(materialList[1].Name, Is.EqualTo("Material 2"));
            Assert.That(materialList[1].Description, Is.EqualTo("Description for Material 2"));
        }
    }
    // The NuGet package required for NUnit assertions is: NUnit  
    // You can install it using the following command in the NuGet Package Manager Console:  
    // Install-Package NUnit
}
