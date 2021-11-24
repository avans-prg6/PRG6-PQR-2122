using Architecture.ASP.Controllers;
using Architecture.ASP.Models;
using Architecture.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace Architecture.ASP.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //arrange
            var form = new FormViewModel();
            form.IsHoliday = true;
            form.Omschrijving = null;

            var controller = new HomeController(null, null, null);

            //act
            ViewResult result = controller.PostForm(form) as ViewResult;

            //assert        
            Assert.AreEqual(1, controller.ModelState.Count);

        }

        [Test]
        public void Test2()
        {
            //arrange
            var form = new FormViewModel();
            form.IsHoliday = true;
            form.Omschrijving = "Stijn gaat naar belgië";

            var mock = new Mock<IVakantieService>();

            var controller = new HomeController(null, mock.Object, null);

            //act
            ViewResult result = controller.PostForm(form) as ViewResult;

            //assert        
            Assert.AreEqual(0, controller.ModelState.Count);
            mock.Verify(m => m.PlanVakantie(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<String>()), Times.Once);
        }
    }
}