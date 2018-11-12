using Lab_MVC.Models;
using System.Collections.Generic;

namespace Lab_MVC.Interfaces.Repositories
{
    public interface IPaymentTransactionRepository
    {
        IEnumerable<PaymentTransaction> GetPaymentTransactions(string lastName, string theLastFourDigitalOfCreditCard);
        PaymentTransaction GetTransactionByInvoiceId(int invoiceId);
    }
}