using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
