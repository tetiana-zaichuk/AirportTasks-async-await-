using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Aircraft: Entity
    {
        public string AircraftName { get; set; }
        public AircraftType AircraftType { get; set; }
        public DateTime AircraftReleaseDate { get; set; }
        [NotMapped]
        public TimeSpan ExploitationTimeSpan { get; set; }
        public long ExploitationTimeSpanTicks
        {
            get => ExploitationTimeSpan.Ticks;
            set => ExploitationTimeSpan = TimeSpan.FromTicks(value);
        }
        
        public int? DepartureId { get; set; }
        [ForeignKey("DepartureId")]
        public Departure Departure { get; set; }
    }
}
