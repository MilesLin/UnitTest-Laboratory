using AutoFixture;
using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;
using AutoFixture.AutoNSubstitute;
using Lab_MVC.Tests;
using AutoFixture.Xunit2;

namespace Lab_MVC.Services.Tests
{
    public class InvoiceServiceWithAutoMockingTests
    {
        [Fact()]
        public void SetInvoiceAsPaidTest()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoNSubstituteCustomization());

            var paymentTransactionRepository = fixture.Freeze<IPaymentTransactionRepository>();
            paymentTransactionRepository.GetTransactionByInvoiceId(Arg.Any<int>()).Returns(
                new PaymentTransaction()
                {
                    Amount = 300
                });
            var payPalService = fixture.Freeze<IPayPalService>();

            int invoiceId = 123;
            int paidAmount = 300;

            var sut = fixture.Create<InvoiceService>();

            // Act
            sut.SetInvoiceAsPaid(invoiceId, paidAmount);

            // Assert
            payPalService.Received().Paid(invoiceId, true);
        }

        [Theory, AutoNSubstituteData]
        public void SetInvoiceAsPaidWithFrozenTest(
            [Frozen]IPaymentTransactionRepository paymentTransactionRepository,
            [Frozen]IPayPalService payPalService,
            InvoiceService sut
            )
        {
            // Arrange
            paymentTransactionRepository.GetTransactionByInvoiceId(Arg.Any<int>()).Returns(
                new PaymentTransaction()
                {
                    Amount = 300
                });

            int invoiceId = 123;
            int paidAmount = 300;

            // Act
            sut.SetInvoiceAsPaid(invoiceId, paidAmount);

            // Assert
            payPalService.Received().Paid(invoiceId, true);
        }
    }
}