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

            // FilePathResult：回應一個實體檔案的內容。 多 FileName 屬性可以用
            // FileContentResult：回應一個byte[] 內容。 多 FileContents 屬性可以用
            // FileStreamResult：回應一個Stream 內容。  多 FileStream 屬性可以用

            // Assert
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetJsonTest()
        {
            // Arrange
            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetJson() as JsonResult;

            //匿名型別的測試方式
            //AssemblyInfo 加入 [assembly: InternalsVisibleTo("Lab-MVC.Tests")] 就可以用 dynamic
            //https://stackoverflow.com/questions/8318845/how-to-unit-test-jsonresult-and-collections-in-mstest/9782001

            //可用 ToExpectedObject() 驗證
            var expected = new { Name = "Miles" };
            expected.ToExpectedObject().ShouldMatch(actual.Data);

            //var a = actual.Data as dynamic;
            //var b = a.Name;
            // 可測試項目
            var a = actual.Data;
            var c = actual.ContentEncoding;
            var d = actual.ContentType;
            var e = actual.JsonRequestBehavior;
            var f = actual.MaxJsonLength;
            var g = actual.RecursionLimit;
            var k = actual.ToUsefulString();

            //轉型可以測試讀取的 file name
            //var c = ((FilePathResult)actual).FileName;

            // Assert

            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetJavaScriptResultTest()
        {
            // Arrange
            string expected = "alert('hi')";
            var sut = new MVCDemoController();

            // Act
            var actual = sut.GetJavaScriptResult() as JavaScriptResult;

            // 只有 actual.Script 可以測試
            Assert.Equal(expected, actual.Script);
        }

    }
}