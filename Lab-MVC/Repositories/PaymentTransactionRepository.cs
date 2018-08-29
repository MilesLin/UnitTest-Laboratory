using Lab_MVC.Models;
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

        public PaymentTransaction GetLastPaymentTransactions(string lastName, string theLastFourDigitalOfCreditCard)
        {
            var paymentTransactions = _db.PaymentTransactions
                .Where(x => x.LastName == lastName && x.LastFourNumberOfCard == theLastFourDigitalOfCreditCard)
                .OrderByDescending(x => x.EntryDateTime);

            return paymentTransactions.FirstOrDefault() ?? default(PaymentTransaction);
        }
    }
}