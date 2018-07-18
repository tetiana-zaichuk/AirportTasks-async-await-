using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
