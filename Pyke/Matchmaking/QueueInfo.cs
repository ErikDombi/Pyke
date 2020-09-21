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
        public ulong DodgerId;

        [JsonProperty("state")]
        public string State;
    }

    public class LowPriorityData
    {
        [JsonProperty("bustedLeaverAccessToken")]
        public string BustedLeaverAccessToken;

        [JsonProperty("penalizedSummonerIds")]
        public List<ulong> PenalizedSummonerIds;

        [JsonProperty("penaltyTime")]
        public double PenaltyTime;

        [JsonProperty("penaltyTimeRemaining")]
        public double PenaltyTimeRemaining;

        [JsonProperty("reason")]
        public string Reason;
    }

    public class QueueInfo
    {
        [JsonProperty("dodgeData")]
        public DodgeData DodgeData;

        [JsonProperty("errors")]
        public List<SearchErrorResource> Errors;

        [JsonProperty("estimatedQueueTime")]
        public double EstimatedQueueTime;

        [JsonProperty("isCurrentlyInQueue")]
        public bool IsCurrentlyInQueue;

        [JsonProperty("lobbyId")]
        public string LobbyId;

        [JsonProperty("lowPriorityData")]
        public LowPriorityData LowPriorityData;

        [JsonProperty("queueId")]
        public ulong QueueId;

        [JsonProperty("readyCheck")]
        public ReadyCheck ReadyCheck;

        [JsonProperty("searchState")]
        public string SearchState;

        [JsonProperty("timeInQueue")]
        public double TimeInQueue;
    }

    public class SearchErrorResource
    {
        public string errorType;
        public ulong id;
        public string message;
        public ulong penalizedSummonerId;
        public double penaltyTimeRemaining;
    }

    public enum SearchResourceSearchState
    {
        Invalid,
        AbandonedLowPriorityQueue,
        Canceled,
        Searching,
        Found,
        Error,
        ServiceError,
        ServiceShutdown
    }

    public enum DodgeDataState
    {
        Invalid,
        PartyDodged,
        StrangerDodged,
        TournamentDodged
    }
}
