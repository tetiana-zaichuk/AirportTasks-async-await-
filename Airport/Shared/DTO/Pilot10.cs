using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.DTO
{
    public class Pilot10
    {
        public string id { get; set; }
        public string crewId { get; set; }
        public DateTime birthDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int exp { get; set; }
    }
}
