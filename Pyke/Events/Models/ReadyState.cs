using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Events.Models
{
    public class ReadyState
    {
        // /lol-matchmaking/v1/ready-check

        [JsonProperty("declinerIds")]
        public List<int> DeclinerIds { get; set; }

        [JsonProperty("dodgeWarning")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReadyStateDodgeWarning DodgeWarning { get; set; }

        [JsonProperty("playerResponse")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReadyStatePlayerResponse PlayerResponse { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReadyStateState state { get; set; }

        [JsonProperty("suppressUx")]
        public bool SuppressUx { get; set; }

        [JsonProperty("timer")]
        public long Timer { get; set; }
    }

    public enum ReadyStateDodgeWarning
    {
        None,
        Warning,
        Penalty
    }

    public enum ReadyStatePlayerResponse 
    { 
        None,
        Accepted,
        Declined
    }

    public enum ReadyStateState
    {
        Invalid,
        InProgress,
        EveryoneReady,
        StrangerNotReady,
        PartyNotReady,
        Error
    }
}
