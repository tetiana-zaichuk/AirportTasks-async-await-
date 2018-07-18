using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shared.DTO
{
    public class Stewardess
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty("birthDate")]
        public DateTime Dob { get; set; }
        [JsonProperty("crewId")]
        public int? CrewId { get; set; }
        //public Crew Crew { get; set; }
    }
}
