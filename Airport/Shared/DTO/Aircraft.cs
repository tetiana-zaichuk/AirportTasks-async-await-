using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shared.DTO
{
    public class Aircraft
    {
       
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string AircraftName { get; set; }
        [Required]
        public AircraftType AircraftType { get; set; }
        [Required]
        public DateTime AircraftReleaseDate { get; set; }
        [Required]
        public TimeSpan ExploitationTimeSpan { get; set; }
        
    }
}
