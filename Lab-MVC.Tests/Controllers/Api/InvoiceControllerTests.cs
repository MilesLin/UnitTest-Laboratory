﻿using Lab_MVC.Controllers.Api;
using ExpectedObjects;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models.ViewModels;
using NSubstitute;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace Lab_MVC.Controllers.Api.Tests
{
    public class InvoiceControllerTests
    {
        [Fact()]
        public void GetInvoicesTest()
        {
            // Arrange
            var invoices = new List<Invoice>()
            {
                new Invoice(){CardNumber = "1234", Name="Miles" }
            };

            var invoiceService = Substitute.For<IInvoiceService>();
            invoiceService.GetInvoices(Arg.Any<Invoice>()).Returns(invoices);

            var logger = Substitute.For<ILog>();

            var sut = new InvoiceController(invoiceService, logger);

            var condition = new Invoice() { CardNumber = "1234" };

            // Act
            var result = sut.GetInvoices(condition) as OkNegotiatedContentResult<List<Invoice>>;
            var actual = result.Content;

            // Assert
            logger.Received(2).Trace(Arg.Any<string>());
            invoices.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact()]
        public void GetAnonymousTypeTest()
        {
            // Arrange            
            var sut = new InvoiceController(null, null);

            // Act
            dynamic result = sut.GetAnonymousType();

            // Assert
            Assert.Equal(1, result.Content.Id);
            Assert.Equal("Miles", result.Content.Name);
        }

        [Fact()]
        public void CreateInvoiceTest()
        {
            // Arrange
            var invoice = new Invoice() { CardNumber = "1234" };
            var expected = invoice;
            var invoiceService = Substitute.For<IInvoiceService>();
            invoiceService.CreateInvoice(Arg.Any<Invoice>()).Returns(invoice);

            var logger = Substitute.For<ILog>();

            var sut = new InvoiceController(invoiceService, logger);

            // Act
            var result = sut.CreateInvoice(invoice) as OkNegotiatedContentResult<Invoice>;
            var actual = result.Content;

            // Assert
            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}