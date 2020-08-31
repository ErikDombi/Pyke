using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Matchmaking
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class DodgeData
    {
        [JsonProperty("dodgerId")]
        public int DodgerId;

        [JsonProperty("state")]
        public string State;
    }

    public class LowPriorityData
    {
        [JsonProperty("bustedLeaverAccessToken")]
        public string BustedLeaverAccessToken;

        [JsonProperty("penalizedSummonerIds")]
        public List<object> PenalizedSummonerIds;

        [JsonProperty("penaltyTime")]
        public int PenaltyTime;

        [JsonProperty("penaltyTimeRemaining")]
        public int PenaltyTimeRemaining;

        [JsonProperty("reason")]
        public string Reason;
    }

    public class QueueInfo
    {
        [JsonProperty("dodgeData")]
        public DodgeData DodgeData;

        [JsonProperty("errors")]
        public List<object> Errors;

        [JsonProperty("estimatedQueueTime")]
        public double EstimatedQueueTime;

        [JsonProperty("isCurrentlyInQueue")]
        public bool IsCurrentlyInQueue;

        [JsonProperty("lobbyId")]
        public string LobbyId;

        [JsonProperty("lowPriorityData")]
        public LowPriorityData LowPriorityData;

        [JsonProperty("queueId")]
        public int QueueId;

        [JsonProperty("readyCheck")]
        public ReadyCheck ReadyCheck;

        [JsonProperty("searchState")]
        public string SearchState;

        [JsonProperty("timeInQueue")]
        public int TimeInQueue;
    }


}
