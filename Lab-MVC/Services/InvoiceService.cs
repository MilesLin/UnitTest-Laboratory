using Lab_MVC.Repositories;
using System.Linq;

namespace Lab_MVC.Services
{
    public class InvoiceService
    {
        private PaymentTransactionRepository _paymentTransactionRepository;
        private PayPalService _payPalService;

        public InvoiceService()
        {
            _paymentTransactionRepository = new PaymentTransactionRepository();
            _payPalService = new PayPalService();
        }

        public bool SendInvoice(string lastName, string theLastFourDigitalOfCreditCard)
        {
            var paymentTransactions = this._paymentTransactionRepository.GetPaymentTransactions(lastName, theLastFourDigitalOfCreditCard);

            var paymentTransaction = paymentTransactions.OrderByDescending(x => x.EntryDateTime).FirstOrDefault();

            string merchantPNRef = paymentTransaction.MerchantPNRef;

            bool isSent = this._payPalService.SendInvoice(merchantPNRef);

            return isSent;
        }
    }
}