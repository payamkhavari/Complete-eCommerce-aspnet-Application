using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Display(Name = "Profile Picture Url")]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        public string? FullName { get; set; }
        [Display(Name ="Biography")]
        public string? Bio { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
