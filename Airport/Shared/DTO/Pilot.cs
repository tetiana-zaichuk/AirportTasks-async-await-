using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shared.DTO
{
    public class Pilot
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public int Experience { get; set; }
        public int? CrewId { get; set; }
    }
}
