using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Departure
    {
        public int Id { get; set; }
        [Required]
        public Flight Flight { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public Crew Crew { get; set; }
        [Required]
        public Aircraft Aircraft { get; set; }
    }
}
