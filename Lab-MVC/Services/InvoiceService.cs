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
            // 從資料庫取的「交易紀錄」
            var paymentTransactions = this._paymentTransactionRepository.GetPaymentTransactions(lastName, theLastFourDigitalOfCreditCard);

            // 取得最後一筆交易紀錄
            var paymentTransaction = paymentTransactions.OrderByDescending(x => x.EntryDateTime).FirstOrDefault();

            // 從交易紀錄取得 Reference Number
            string merchantPNRef = paymentTransaction.MerchantPNRef;

            // 呼叫 PayPal API，寄送發票
            bool isSent = this._payPalService.SendInvoice(merchantPNRef);

            // 回傳是否寄送成功
            return isSent;
        }
    }
}