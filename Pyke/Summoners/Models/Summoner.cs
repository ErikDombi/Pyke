using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Summoners.Models
{
    public class RerollPoints
    {
        [JsonProperty("currentPoints")]
        public int CurrentPoints;

        [JsonProperty("maxRolls")]
        public int MaxRolls;

        [JsonProperty("numberOfRolls")]
        public int NumberOfRolls;

        [JsonProperty("pointsCostToRoll")]
        public int PointsCostToRoll;

        [JsonProperty("pointsToReroll")]
        public int PointsToReroll;
    }

    public class Summoner
    {
        [JsonProperty("accountId")]
        public int AccountId;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("internalName")]
        public string InternalName;

        [JsonProperty("percentCompleteForNextLevel")]
        public int PercentCompleteForNextLevel;

        [JsonProperty("profileIconId")]
        public int ProfileIconId;

        [JsonProperty("puuid")]
        public string Puuid;

        [JsonProperty("rerollPoints")]
        public RerollPoints RerollPoints;

        [JsonProperty("summonerId")]
        public int SummonerId;

        [JsonProperty("summonerLevel")]
        public int SummonerLevel;

        [JsonProperty("xpSinceLastLevel")]
        public int XpSinceLastLevel;

        [JsonProperty("xpUntilNextLevel")]
        public int XpUntilNextLevel;
    }

}
