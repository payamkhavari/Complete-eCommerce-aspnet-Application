using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Display(Name="Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Satat Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }

    }
}
