using Lab_MVC.Models.ViewModels;
using System.Collections.Generic;

namespace Lab_MVC.Interfaces.Services
{
    public interface IInvoiceService
    {
        bool SendInvoice(string lastName, string theLastFourDigitalOfCreditCard);

        List<Invoice> GetInvoices(Invoice invoice);
    }
}