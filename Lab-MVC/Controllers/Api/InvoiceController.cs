using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models.ViewModels;
using Lab_MVC.Repositories;
using Lab_MVC.Services;
using Newtonsoft.Json;
using System.Web.Http;

namespace Lab_MVC.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private IInvoiceService _invoiceService;
        private ILog _logger;

        public InvoiceController(
            IInvoiceService invoiceService,
            ILog logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet]
        public IHttpActionResult GetInvoices(Invoice filter)
        {
            this._logger.Trace($"{nameof(GetInvoices)}.GetInvoices: {JsonConvert.SerializeObject(filter)}");

            var invoices = this._invoiceService.GetInvoices(filter);

            this._logger.Trace($"{nameof(GetInvoices)}.GetInvoices: {JsonConvert.SerializeObject(invoices)}");

            return Ok(invoices);
        }

        [HttpPost]
        [Route("CreateInvoice")]
        public IHttpActionResult CreateInvoice(Invoice invoice)
        {
            var result = this._invoiceService.CreateInvoice(invoice);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetAnonymousType()
        {
            var result = new { Id = 1, Name = "Miles" };
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PostSendInvoice(string lastName, string theLastFourDigitalOfCreditCard)
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