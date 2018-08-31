using Xunit;
using Lab_MVC.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Lab_MVC.Models;

namespace Lab_MVC.Controllers.Api.Tests
{
    public class WebAPIDemoControllerTests
    {
        [Fact()]
        public void GetOkTest()
        {
            // Arrange

            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetOk() as OkNegotiatedContentResult<Train>;

            var a = result.Content;

            // Assert
            //Assert.Equal(expected, result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetOkWithAnonymousTest()
        {            
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            dynamic result = sut.GetOkWithAnonymous();

            var a = result.Content;

            // Assert
            //Assert.Equal(expected, result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }
    }
}