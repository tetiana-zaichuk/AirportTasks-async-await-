using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Flight : Entity
    {
        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }

        public int? DepartureId { get; set; }
        [ForeignKey("DepartureId")]
        public Departure DepartureEvent { get; set; }
    }
}
