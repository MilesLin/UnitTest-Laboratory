using Lab_MVC.Interfaces.Services;
using RestSharp;
using System;
using System.Configuration;
using System.Text;

namespace Lab_MVC.Services
{
    public class PayPalService : IPayPalService
    {
        private string _host = "https://paypal";

        private IRestClient _restClient;

        public PayPalService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public string GetAccessToken(string clientId, string secret)
        {
            string endPoint = $@"{this._host}/oauth2/token";
            Uri uri = new Uri(endPoint);
            _restClient.BaseUrl = uri;
            
            string authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{secret}"));

            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", $"Basic {authorization}");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);
            //IRestResponse response = _restClient.Execute(request);

            return "";
            //return response.Content;
        }

        public void Paid(int invoiceId, bool isPaidOff)
        {
            throw new NotImplementedException();
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