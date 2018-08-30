using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Repositories;
using System.Linq;

namespace Lab_MVC.Services
{
    public class InvoiceService
    {
        private IPaymentTransactionRepository _paymentTransactionRepository;
        private IPayPalService _payPalService;

        public InvoiceService(
            IPaymentTransactionRepository paymentTransactionRepository,
            IPayPalService payPalService
            )
        {
            _paymentTransactionRepository = paymentTransactionRepository;
            _payPalService = payPalService;
        }

        public bool SendInvoice(string lastName, string theLastFourDigitalOfCreditCard)
        {
            // 根據「姓氏」與「信用卡後四碼」從資料庫取得「交易紀錄」
            var paymentTransactions = this._paymentTransactionRepository
                .GetPaymentTransactions(lastName, theLastFourDigitalOfCreditCard);

            // 取得最後一筆交易紀錄
            var paymentTransaction = paymentTransactions
                .OrderByDescending(x => x.EntryDateTime)
                .FirstOrDefault();

            // 從交易紀錄取得 Reference Number
            string merchantPNRef = paymentTransaction.MerchantPNRef;

            // 呼叫 PayPal API，寄送發票
            bool isSent = this._payPalService.SendInvoice(merchantPNRef);

            // 回傳是否寄送成功
            return isSent;
        }
    }
}