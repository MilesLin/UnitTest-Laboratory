namespace Lab_MVC.Interfaces.Services
{
    public interface IPayPalService
    {
        bool SendInvoice(string merchantPNRef);
        string GetAccessToken(string clientId, string secret);
        void Paid(int invoiceId, bool isPaidOff);
    }
}