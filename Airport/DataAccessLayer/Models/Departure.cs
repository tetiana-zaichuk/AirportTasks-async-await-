using System;

namespace DataAccessLayer.Models
{
    public class Departure: Entity
    {
        public Flight Flight { get; set; }
        public DateTime DepartureDate { get; set; }
        public Crew Crew { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}
