using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shared.DTO
{
    public class Pilot
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        [Required]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [JsonProperty("birthDate")]
        public DateTime Dob { get; set; }
        [Required]
        [JsonProperty("exp")]
        public int Experience { get; set; }
        [JsonProperty("crewId")] 
        public int? CrewId { get; set; }
    }
}
