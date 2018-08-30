using Lab_MVC.Interfaces.Services;
using RestSharp;
using System;
using System.Configuration;

namespace Lab_MVC.Services
{
    public class PayPalService : IPayPalService
    {
        private string _host;

        private RestClient _restClient;

        public PayPalService()
        {
            _restClient = new RestClient();
            _host = ConfigurationManager.AppSettings["APIHost"];
        }

        public bool SendInvoice(string merchantPNRef)
        {
            string endPoint = $@"{this._host}/invoicing/invoices/{merchantPNRef}/send";
            Uri uri = new Uri(endPoint);
            this._restClient.BaseUrl = uri;

            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = this._restClient.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}