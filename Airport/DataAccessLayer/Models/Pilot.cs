using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Pilot : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int Experience { get; set; }
        
        public int CrewId { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }
    }
}
