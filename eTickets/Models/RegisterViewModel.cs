using Microsoft.CodeAnalysis.Options;

namespace eTickets.Models
{
    public class RegisterViewModel
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
