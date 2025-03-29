using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="EmailAddress cannot be blank")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="EmailAddress should be in proper email Address Format")]
        public string EmailAddress { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage = "Password cannot be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
