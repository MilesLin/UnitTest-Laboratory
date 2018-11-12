using Lab_MVC.Services;
using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models;
using NSubstitute;
using RestSharp;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lab_MVC.Services.Tests
{
    public class InvoiceServiceTests
    {
        [Fact()]
        public void SendInvoiceTest()
        {
            // Arrange
            string lastName = "Lin";
            string theLastFourDigital = "1234";
            string expectedMerchantPNRef = "Ref567";

            List<PaymentTransaction> paymentTransaction = new List<PaymentTransaction>()
            {
                new PaymentTransaction{ MerchantPNRef = "Ref123", EntryDateTime = new DateTime(2018, 8, 29), LastName = "Lin", LastFourNumberOfCard = "1234" },
                new PaymentTransaction{ MerchantPNRef = expectedMerchantPNRef, EntryDateTime = new DateTime(2018, 8, 30), LastName = "Lin", LastFourNumberOfCard = "1234" }
            };

            var paymentTransactionRepository = Substitute.For<IPaymentTransactionRepository>();
            paymentTransactionRepository
                .GetPaymentTransactions(Arg.Is<string>(x => x == "Lin"), Arg.Is<string>(x => x == "1234"))
                .Returns(paymentTransaction);

            var payPalService = Substitute.For<IPayPalService>();
            payPalService
                .SendInvoice(Arg.Is<string>(x => x == expectedMerchantPNRef))
                .Returns(true);

            var sut = new InvoiceService(paymentTransactionRepository, payPalService, null);

            // Act
            var result = sut.SendInvoice(lastName, theLastFourDigital);

            // Assert
            paymentTransactionRepository.Received(1)
                .GetPaymentTransactions(Arg.Is<string>(x => x == "Lin"), Arg.Is<string>(x => x == "1234"));
            payPalService.Received(1).SendInvoice(Arg.Is<string>(x => x == expectedMerchantPNRef));
            Assert.True(result);
        }

        [Fact()]
        public void SetInvoiceAsPaidTest()
        {
            // Arrange
            var paymentTransactionRepository = Substitute.For<IPaymentTransactionRepository>();
            paymentTransactionRepository.GetTransactionByInvoiceId(Arg.Any<int>()).Returns(
                new PaymentTransaction()
                {
                    Amount = 300
                });
            var payPalService = Substitute.For<IPayPalService>();
            var sut = new InvoiceService(paymentTransactionRepository, payPalService, null);

            int invoiceId = 123;
            int paidAmount = 300;

            // Act
            sut.SetInvoiceAsPaid(invoiceId, paidAmount);

            // Assert
            payPalService.Received().Paid(invoiceId, true);
        }

    }
}