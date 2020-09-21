using Newtonsoft.Json;
using Pyke.Events.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Matchmaking
{
    public class ReadyCheck
    {
        [JsonProperty("declinerIds")]
        public List<object> DeclinerIds;

        [JsonProperty("dodgeWarning")]
        public string DodgeWarning;

        [JsonProperty("playerResponse")]
        public string PlayerResponse;

        [JsonProperty("state")]
        public ReadyStateState State;

        [JsonProperty("suppressUx")]
        public bool SuppressUx;

        [JsonProperty("timer")]
        public double Timer;
    }


}
