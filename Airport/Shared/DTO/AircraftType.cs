using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class AircraftType
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string AircraftModel { get; set; }
        [Required]
        public int SeatsNumber { get; set; }
        [Required]
        public int Carrying { get; set; }
    }
}
