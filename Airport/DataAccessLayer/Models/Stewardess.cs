using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Stewardess : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        
        public int? CrewId { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }
    }
}
