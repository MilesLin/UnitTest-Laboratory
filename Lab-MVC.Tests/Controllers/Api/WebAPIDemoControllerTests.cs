using Lab_MVC.Models;
using System.Web.Http.Results;
using Xunit;

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

        [Fact()]
        public void GetOkWithNoArgumentTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetOkWithNoArgument();

            // Assert
            Assert.IsType<OkResult>(result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetBadRequestTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetBadRequest() as BadRequestResult;

            // Assert
            Assert.IsType<BadRequestResult>(result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetBadRequestWithStringMessageTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetBadRequestWithStringMessage() as BadRequestErrorMessageResult;
            var a = result.Message;

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetBadRequestWithModelStateTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetBadRequestWithModelState() as InvalidModelStateResult;
            var b = result.ModelState;
            var c = b["a"];
            var d = b["err"];
            var d1 = d.Errors[0].ErrorMessage;
            // Assert
            Assert.IsType<InvalidModelStateResult>(result);
            //expected.ToExpectedObject().ShouldMatch(result);
        }

        [Fact()]
        public void GetConflictTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetConflict() as ConflictResult;

            // Assert
            Assert.IsType<ConflictResult>(result);
        }
    }
}