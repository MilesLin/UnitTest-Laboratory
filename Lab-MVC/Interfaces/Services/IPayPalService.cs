namespace Lab_MVC.Interfaces.Services
{
    public interface IPayPalService
    {
        bool SendInvoice(string merchantPNRef);
    }
}