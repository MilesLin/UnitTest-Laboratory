using ExpectedObjects;
using Lab_MVC.Models;
using System;
using System.Web.Mvc;
using Xunit;

namespace Lab_MVC.Controllers.Tests
{
    public class MVCDemoControllerTests
    {
        [Fact()]
        public void GetViewTest()
        {
            //arrange
            int trainId = 1;
            var expected = new
            {
                TrainId = 1,
                TrainName = "XY-3443",
                Destination = "Torrance",
                DepartureTime = new DateTime(2018, 10, 1)
            };

            var sut = new MVCDemoController();

            //act
            var actual = sut.GetView(trainId) as ViewResult;
            var result = actual.Model as Train;

            // 其他可測試項目
            //actual.TempData["Key"]
            //actual.ViewData["Key"]
            //actual.ViewName

            //assert
            expected.ToExpectedObject().ShouldMatch(result);
        }
    }
}