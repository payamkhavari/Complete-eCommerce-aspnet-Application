using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int CinemaId { get; set; }
        public string? CinemaLogo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
