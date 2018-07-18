using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.DTO
{
    public class Stewardess10
    {
        public string id { get; set; }
        public string crewId { get; set; }
        public DateTime birthDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
