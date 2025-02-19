using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : BaseModel
    {
        [Key]
        public int ProducerId { get; set; }
        public List<Movie> Movies  { get; set; }
    }
}
