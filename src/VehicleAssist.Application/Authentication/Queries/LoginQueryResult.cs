using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VehicleAssist.Application.Authentication
{
    public record LoginQueryResult
    {
        [JsonPropertyName("userId")]
        public int userId { get; set; }

        [JsonPropertyName("token")]
        public string token { get; set; }
    }
}
