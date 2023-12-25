using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Models
{
    public class AImodel
    {
        [JsonPropertyName("source")]

        public string source { get; set; }

        [JsonPropertyName("headline")]

        public string headline { get; set; }

        [JsonPropertyName("content")]
        public string content { get; set; }
    }
}
