﻿using Lab_MVC.Controllers;
using System.Web.Mvc;
using Xunit;

namespace Lab_MVC.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(null, null);

            // Act
            ViewResult result = controller.Index(null) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(null, null);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.Equal("Your application description page.", result.ViewBag.Message);
        }

        [Fact]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(null, null);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}