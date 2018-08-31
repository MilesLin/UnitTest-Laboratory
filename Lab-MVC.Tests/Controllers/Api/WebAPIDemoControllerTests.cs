﻿using Lab_MVC.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        [Fact()]
        public void GetContentTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetContent() as NegotiatedContentResult<int>;
            var a = result.StatusCode;
            var b = result.Content;

            // Assert
            Assert.IsType<ConflictResult>(result);
        }

        [Fact()]
        public void GetCreatedTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetCreated() as CreatedNegotiatedContentResult<Train>;
            var a = result.Content;
            var b = result.Location;

            // Assert
        }

        [Fact()]
        public void GetInternalServerErrorTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetInternalServerError() as ExceptionResult;
            var a = result.Exception;

            // Assert
            Assert.IsType<ArgumentNullException>(result.Exception);
        }

        [Fact()]
        public void GetInternalServerErrorWithNoArgTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetInternalServerErrorWithNoArg();

            // Assert
            Assert.IsType<InternalServerErrorResult>(result);
        }

        [Fact()]
        public void GetJsonTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetJson() as JsonResult<Train>;
            var a = result.Content;
            var b = result.Encoding;

            // Assert
        }

        [Fact()]
        public void GetNotFoundTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetNotFound();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact()]
        public void GetRedirectTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetRedirect() as RedirectResult;
            var a = result.Location;

            // Assert
        }

        [Fact()]
        public void GetRedirectToRouteTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetRedirectToRoute() as RedirectToRouteResult;
            var a = result.RouteName;
            var b = result.RouteValues;
            var c = result.RouteValues["id"];

            // Assert
        }

        [Fact()]
        public void GetStatusCodeTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetStatusCode() as StatusCodeResult;

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact()]
        public void GetUnauthorizedTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();

            // Act
            var result = sut.GetUnauthorized() as UnauthorizedResult;
            var a = result.Challenges;
            // 這段還要研究要測試什麼

            // Assert
            
        }

        [Fact()]
        public void GetResponseMessageTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();
            sut.Request = new HttpRequestMessage();            

            // Act
            var result = sut.GetResponseMessage() as ResponseMessageResult;
            var a = result.Response.StatusCode;
            
            // Assert
        }

        [Fact()]
        public void GetHttpResponseMessageTest()
        {
            // Arrange
            var sut = new WebAPIDemoController();
            sut.Request = new HttpRequestMessage();
            sut.Configuration = new HttpConfiguration();
            
            // Act
            var result = sut.GetHttpResponseMessage();
            var a = result.Headers;
            var b = result.StatusCode;
            var c = result.Content;
            var d = result.TryGetContentValue<Train>(out Train train);
            var e = train.TrainId;
            

            // Assert

        }

    }
}