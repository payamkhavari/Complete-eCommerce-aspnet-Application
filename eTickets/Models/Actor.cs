using eTickets.Data.Base;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        //public int ActorId { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="profile picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
        public virtual List<Actor_Movie> Actor_Movies { get; set; }
        
    }
}
