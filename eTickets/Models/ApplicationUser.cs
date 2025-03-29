using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
