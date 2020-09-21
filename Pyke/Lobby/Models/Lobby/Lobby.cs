using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pyke.Lobby.Models.Lobby
{
    public class Details
    {
    }

    public class GatekeeperRestriction
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("remainingMillis")]
        public int RemainingMillis { get; set; }
    }

    public class ActiveRestrictions
    {
        [JsonProperty("gatekeeperRestrictions")]
        public List<GatekeeperRestriction> GatekeeperRestrictions { get; set; }
    }

    public class Chat
    {
        [JsonProperty("jid")]
        public string Jid { get; set; }
    }

    public class EligibilityRestriction
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("remainingMillis")]
        public int RemainingMillis { get; set; }
    }

    public class Details3
    {
    }

    public class EligibilityWarning
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("details")]
        public Details3 Details { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("remainingMillis")]
        public int RemainingMillis { get; set; }
    }

    public class GameCustomization
    {
    }

    public class GameMode
    {
        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("gameCustomization")]
        public GameCustomization GameCustomization { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("maxPartySize")]
        public int MaxPartySize { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }
    }

    public class GameCustomization2
    {
    }

    public class GameMode2
    {
        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("gameCustomization")]
        public GameCustomization2 GameCustomization { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("maxPartySize")]
        public int MaxPartySize { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("championSelection")]
        public int ChampionSelection { get; set; }

        [JsonProperty("positionPref")]
        public List<string> PositionPref { get; set; }

        [JsonProperty("skinSelection")]
        public int SkinSelection { get; set; }
    }

    public class Player
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("canInvite")]
        public bool CanInvite { get; set; }

        [JsonProperty("gameMode")]
        public GameMode2 GameMode { get; set; }

        [JsonProperty("inviteTimestamp")]
        public int InviteTimestamp { get; set; }

        [JsonProperty("invitedBySummonerId")]
        public ulong InvitedBySummonerId { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }

        [JsonProperty("partyVersion")]
        public int PartyVersion { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }
    }

    public class CurrentParty
    {
        [JsonProperty("activeRestrictions")]
        public ActiveRestrictions ActiveRestrictions { get; set; }

        [JsonProperty("activityLocked")]
        public bool ActivityLocked { get; set; }

        [JsonProperty("activityResumeUtcMillis")]
        public int ActivityResumeUtcMillis { get; set; }

        [JsonProperty("activityStartedUtcMillis")]
        public int ActivityStartedUtcMillis { get; set; }

        [JsonProperty("chat")]
        public Chat Chat { get; set; }

        [JsonProperty("eligibilityHash")]
        public int EligibilityHash { get; set; }

        [JsonProperty("eligibilityRestrictions")]
        public List<EligibilityRestriction> EligibilityRestrictions { get; set; }

        [JsonProperty("eligibilityWarnings")]
        public List<EligibilityWarning> EligibilityWarnings { get; set; }

        [JsonProperty("gameMode")]
        public GameMode GameMode { get; set; }

        [JsonProperty("maxPartySize")]
        public int MaxPartySize { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }

        [JsonProperty("partyType")]
        public string PartyType { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }

    public class GameCustomization3
    {
    }

    public class GameMode3
    {
        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("gameCustomization")]
        public GameCustomization3 GameCustomization { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("maxPartySize")]
        public int MaxPartySize { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }
    }

    public class Metadata2
    {
        [JsonProperty("championSelection")]
        public int ChampionSelection { get; set; }

        [JsonProperty("positionPref")]
        public List<string> PositionPref { get; set; }

        [JsonProperty("skinSelection")]
        public int SkinSelection { get; set; }
    }

    public class Party
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("canInvite")]
        public bool CanInvite { get; set; }

        [JsonProperty("gameMode")]
        public GameMode3 GameMode { get; set; }

        [JsonProperty("inviteTimestamp")]
        public int InviteTimestamp { get; set; }

        [JsonProperty("invitedBySummonerId")]
        public ulong InvitedBySummonerId { get; set; }

        [JsonProperty("metadata")]
        public Metadata2 Metadata { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }

        [JsonProperty("partyVersion")]
        public int PartyVersion { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }
    }

    public class Registration
    {
        [JsonProperty("gameClientVersion")]
        public string GameClientVersion { get; set; }

        [JsonProperty("inventoryToken")]
        public string InventoryToken { get; set; }

        [JsonProperty("inventoryTokens")]
        public List<string> InventoryTokens { get; set; }

        [JsonProperty("rankedOverviewToken")]
        public string RankedOverviewToken { get; set; }

        [JsonProperty("simpleInventoryToken")]
        public string SimpleInventoryToken { get; set; }

        [JsonProperty("summonerToken")]
        public string SummonerToken { get; set; }

        [JsonProperty("userInfoToken")]
        public string UserInfoToken { get; set; }
    }

    public class Lobby
    {
        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("createdAt")]
        public int CreatedAt { get; set; }

        [JsonProperty("currentParty")]
        public CurrentParty CurrentParty { get; set; }

        [JsonProperty("eligibilityHash")]
        public int EligibilityHash { get; set; }

        [JsonProperty("parties")]
        public List<Party> Parties { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("registration")]
        public Registration Registration { get; set; }

        [JsonProperty("serverUtcMillis")]
        public int ServerUtcMillis { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
