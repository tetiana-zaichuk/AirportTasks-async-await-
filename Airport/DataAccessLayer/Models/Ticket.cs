using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Ticket : Entity
    {
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}
