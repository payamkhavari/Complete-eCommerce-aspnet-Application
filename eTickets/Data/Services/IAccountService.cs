namespace eTickets.Data.Services
{
    public interface IAccountService
    {
       Task<bool> CheckRegisteredStatusAsync();
    }
}
