using Lab_MVC.Repositories;
using Lab_MVC.Services;
using System.Web.Http;

namespace Lab_MVC.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private InvoiceService _invoiceService;

        public InvoiceController()
        {
            _invoiceService = new InvoiceService(new PaymentTransactionRepository(), new PayPalService());
        }

        [HttpPost]
        public IHttpActionResult SendInvoice(string lastName, string theLastFourDigitalOfCreditCard)
        {
            bool isSent = _invoiceService.SendInvoice(lastName, theLastFourDigitalOfCreditCard);

            if (isSent)
            {
                return Ok("Email 發送成功");
            }
            else
            {
                return BadRequest("Email 發送失敗");
            }
        }
    }
}