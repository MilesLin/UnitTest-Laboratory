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

            var filter = new Invoice() { CardNumber = "1234" };

            // Act
            var result = sut.GetInvoices(filter) as OkNegotiatedContentResult<List<Invoice>>;
            var actual = result.Content;

            // Assert
            logger.Received(2).Trace(Arg.Any<string>());
            invoices.ToExpectedObject().ShouldMatch(actual);
        }
    }
}