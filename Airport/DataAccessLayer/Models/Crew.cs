using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Crew : Entity
    {
        public Pilot Pilot { get; set; }
        public List<Stewardess> Stewardesses { get; set; }
        
        public int? DepartureId { get; set; }
        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }
    }
}
