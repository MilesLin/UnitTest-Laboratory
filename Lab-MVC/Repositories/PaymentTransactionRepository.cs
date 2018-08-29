using Lab_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab_MVC.Repositories
{
    public class PaymentTransactionRepository
    {
        private WebPayment _db;

        public PaymentTransactionRepository()
        {
            _db = new WebPayment();
        }

        public IEnumerable<PaymentTransaction> GetPaymentTransactions(string lastName, string theLastFourDigitalOfCreditCard)
        {
            var paymentTransactions = _db.PaymentTransactions
                .Where(x => x.LastName == lastName && x.LastFourNumberOfCard == theLastFourDigitalOfCreditCard);

            return paymentTransactions;
        }
    }
}