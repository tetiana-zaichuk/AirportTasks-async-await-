using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.DTO
{
    public class Crew10
    {
        public string id { get; set; }
        public List<Pilot10> pilot { get; set; }
        public List<Stewardess10> stewardess { get; set; }
    }
}
