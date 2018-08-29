using RestSharp;
using System;
using System.Configuration;

namespace Lab_MVC.Services
{
    public class PayPalService
    {
        private string _host;

        private string Host
        {
            get
            {
                if (string.IsNullOrEmpty(_host))
                {
                    _host = ConfigurationManager.AppSettings["APIHost"];
                }
                return _host;
            }
        }

        private RestClient _restClient;

        public PayPalService()
        {
            _restClient = new RestClient();
        }

        public bool SendInvoice(string merchantPNRef)
        {
            string endPoint = $@"{this.Host}/invoicing/invoices/{merchantPNRef}/send";
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