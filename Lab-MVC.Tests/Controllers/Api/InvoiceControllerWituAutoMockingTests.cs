using AutoFixture;
using AutoFixture.AutoNSubstitute;
using ExpectedObjects;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models.ViewModels;
using NSubstitute;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
using System.Web.Mvc;
using Xunit;

namespace Lab_MVC.Controllers.Api.Tests
{
    public class InvoiceControllerWituAutoMockingTests
    {
        [Fact()]
        public void CreateInvoiceTest()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoNSubstituteCustomization());

            fixture.Customize<InvoiceController>(c => c
                .OmitAutoProperties()
                //.With(x => x.Request, fixture.Create<HttpRequestMessage>())
                );
            
            var invoice = new Invoice() { CardNumber = "1234" };
            var expected = invoice;
            var invoiceService = fixture.Freeze<IInvoiceService>();
            invoiceService.CreateInvoice(Arg.Any<Invoice>()).Returns(invoice);

            var logger = fixture.Freeze<ILog>();

            var sut = fixture.Create<InvoiceController>();
            //var sut = new InvoiceController(invoiceService,logger);

            // Act
            var result = sut.CreateInvoice(invoice) as OkNegotiatedContentResult<Invoice>;
            var actual = result.Content;

            // Assert
            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}