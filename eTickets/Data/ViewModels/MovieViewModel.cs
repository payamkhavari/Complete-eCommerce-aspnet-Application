using eTickets.Data.Enums;
using eTickets.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);
        [Display(Name = "Price")]
        public int Price { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }
        public List<int> ActorIds { get; set; }
    }
}
