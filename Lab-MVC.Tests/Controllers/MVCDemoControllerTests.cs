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
            // Arrange
            int trainId = 1;
            var expected = new
            {
                TrainId = 1,
                TrainName = "XY-3443",
                Destination = "Torrance",
                DepartureTime = new DateTime(2018, 10, 1)
            };

            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetView(trainId) as ViewResult;
            var result = actual.Model as Train;

            // 其他可測試項目
            //actual.TempData["Key"]
            //actual.ViewData["Key"]
            //actual.ViewName

            // Assert
            expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetPartialViewTest()
        {
            // Arrange
            int trainId = 1;
            var expected = new
            {
                TrainId = 1,
                TrainName = "XY-3443",
                Destination = "Torrance",
                DepartureTime = new DateTime(2018, 10, 1)
            };

            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetPartialView(trainId) as PartialViewResult;
            var result = actual.Model as Train;
            
            // 其他可測試項目
            //actual.TempData["Key"]
            //actual.ViewData["Key"]
            //actual.ViewName

            // Assert
            expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetContentTest()
        {
            // Arrange            
            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetContent() as ContentResult;

            // 可測試項目
            var a = actual.Content;
            var b = actual.ContentEncoding;
            var c = actual.ContentType;

            // Assert
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetFileTest()
        {
            // Arrange            
            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetContent() as FileResult;

            // 可測試項目
            var a = actual.ContentType;
            var b = actual.FileDownloadName;
            
            //轉型可以測試讀取的 file name
            //var c = ((FilePathResult)actual).FileName;

            // Assert
            //expected.ToExpectedObject().ShouldMatch(result);
        }

    }
}