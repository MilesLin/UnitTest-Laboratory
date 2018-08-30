using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models;
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
            var fakePaymentTransactionRepository = new FakePaymentTransactionRepository();
            var fakePayPalService = new FakePayPalService();

            var sut = new InvoiceService(fakePaymentTransactionRepository, fakePayPalService);

            // Act
            var result = sut.SendInvoice(lastName, theLastFourDigital);

            // Assert
            Assert.True(result);
        }
    }

    public class FakePaymentTransactionRepository : IPaymentTransactionRepository
    {
        public IEnumerable<PaymentTransaction> GetPaymentTransactions(
            string lastName,
            string theLastFourDigitalOfCreditCard)
        {
            if (lastName != "Lin")
            {
                throw new System.Exception("傳入 lastName 參數錯誤");
            }

            if (theLastFourDigitalOfCreditCard != "1234")
            {
                throw new System.Exception("傳入 theLastFourDigitalOfCreditCard 參數錯誤");
            }

            yield return new PaymentTransaction
            { MerchantPNRef = "Ref123", EntryDateTime = new DateTime(2018, 8, 29), LastName = "Lin", LastFourNumberOfCard = "1234" };
            yield return new PaymentTransaction
            { MerchantPNRef = "Ref567", EntryDateTime = new DateTime(2018, 8, 30), LastName = "Lin", LastFourNumberOfCard = "1234" };
        }
    }

    public class FakePayPalService : IPayPalService
    {
        public bool SendInvoice(string merchantPNRef)
        {
            if (merchantPNRef != "Ref567")
            {
                throw new System.Exception("傳入 merchantPNRef 參數錯誤");
            }

            return true;
        }
    }
}