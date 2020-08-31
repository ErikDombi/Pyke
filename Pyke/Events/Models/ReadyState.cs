using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Events.Models
{
    public class ReadyState
    {
        [JsonProperty("declinerIds")]
        public List<object> DeclinerIds { get; set; }

        [JsonProperty("dodgeWarning")]
        public string DodgeWarning { get; set; }

        [JsonProperty("playerResponse")]
        public string PlayerResponse { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("suppressUx")]
        public bool SuppressUx { get; set; }

        [JsonProperty("timer")]
        public long Timer { get; set; }
    }
}
