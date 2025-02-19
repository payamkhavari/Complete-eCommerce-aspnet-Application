using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : BaseModel
    {
        [Key]
        public int ActorId { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
