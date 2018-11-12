using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models;
using Lab_MVC.Models.ViewModels;
using Lab_MVC.Repositories;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_MVC.Services
{
    public class InvoiceService : IInvoiceService
    {
        private string _host = "https://paypal";
        private IPaymentTransactionRepository _paymentTransactionRepository;
        private IPayPalService _payPalService;
        private IRestClient _restClient;

        public InvoiceService(
            IPaymentTransactionRepository paymentTransactionRepository,
            IPayPalService payPalService,
            IRestClient restClient
            )
        {
            _paymentTransactionRepository = paymentTransactionRepository;
            _payPalService = payPalService;
            _restClient = restClient;
        }

        public void SetInvoiceAsPaid(int invoiceId, int paidAmount)
        {
            PaymentTransaction transaction = this._paymentTransactionRepository.GetTransactionByInvoiceId(invoiceId);
            bool isPaidOff = false;
            if (paidAmount >= transaction.Amount)
            {
                isPaidOff = true;
            }
            this._payPalService.Paid(invoiceId, isPaidOff);
        }

        public List<Invoice> GetInvoices(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            string endPoint = $@"{this._host}/invoicing/invoices/";
            Uri uri = new Uri(endPoint);
            this._restClient.BaseUrl = uri;
            
            string invoiceJson = JsonConvert.SerializeObject(invoice);
            
            string accessToken = this._payPalService.GetAccessToken("clientID","Secret");
            
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", $"{accessToken}");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", invoiceJson, ParameterType.RequestBody);
            IRestResponse response = this._restClient.Execute(request);
            
            var result = JsonConvert.DeserializeObject<Invoice>(response.Content);

            return result;
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