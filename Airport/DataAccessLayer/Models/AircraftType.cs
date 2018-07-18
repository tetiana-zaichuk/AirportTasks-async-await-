using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class AircraftType: Entity
    {
        public string AircraftModel { get; set; }
        public int SeatsNumber { get; set; }
        public int Carrying { get; set; }
        
        public int AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }
    }
}
