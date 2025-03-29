using Microsoft.AspNetCore.Identity;

namespace eTickets.Models
{
    public class ApplicationRole: IdentityRole<Guid>
    {
        public ApplicationRole():base() { }
        public ApplicationRole(string roleName):base(roleName)
        {
            
        }
    }
}
