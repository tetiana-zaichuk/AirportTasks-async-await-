using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        public Pilot Pilot { get; set; }
        [Required]
        public List<Stewardess> Stewardesses { get; set; }
    }
}
