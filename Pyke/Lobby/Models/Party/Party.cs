using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Lobby.Models.Party
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class CustomSpectator
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public ulong BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BotDifficulty BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public string BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public ulong SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public ulong TeamId { get; set; }
    }

    public class CustomTeam100
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public ulong BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public ulong BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public ulong SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public ulong TeamId { get; set; }
    }

    public class CustomTeam200
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public ulong BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public string BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public ulong SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public ulong TeamId { get; set; }
    }

    public class GameConfig
    {
        [JsonProperty("allowablePremadeSizes")]
        public List<int> AllowablePremadeSizes { get; set; }

        [JsonProperty("customLobbyName")]
        public string CustomLobbyName { get; set; }

        [JsonProperty("customMutatorName")]
        public string CustomMutatorName { get; set; }

        [JsonProperty("customRewardsDisabledReasons")]
        public List<string> CustomRewardsDisabledReasons { get; set; }

        [JsonProperty("customSpectatorPolicy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SpectatorPolicy CustomSpectatorPolicy { get; set; }

        [JsonProperty("customSpectators")]
        public List<CustomSpectator> CustomSpectators { get; set; }

        [JsonProperty("customTeam100")]
        public List<CustomTeam100> CustomTeam100 { get; set; }

        [JsonProperty("customTeam200")]
        public List<CustomTeam200> CustomTeam200 { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("isCustom")]
        public bool IsCustom { get; set; }

        [JsonProperty("isLobbyFull")]
        public bool IsLobbyFull { get; set; }

        [JsonProperty("isTeamBuilderManaged")]
        public bool IsTeamBuilderManaged { get; set; }

        [JsonProperty("mapId")]
        public ulong MapId { get; set; }

        [JsonProperty("maxHumanPlayers")]
        public int MaxHumanPlayers { get; set; }

        [JsonProperty("maxLobbySize")]
        public int MaxLobbySize { get; set; }

        [JsonProperty("maxTeamSize")]
        public int MaxTeamSize { get; set; }

        [JsonProperty("pickType")]
        public string PickType { get; set; }

        [JsonProperty("premadeSizeAllowed")]
        public bool PremadeSizeAllowed { get; set; }

        [JsonProperty("queueId")]
        public ulong QueueId { get; set; }

        [JsonProperty("showPositionSelector")]
        public bool ShowPositionSelector { get; set; }
    }

    public class Invitation
    {
        [JsonProperty("invitationId")]
        public string InvitationId { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public State State { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("toSummonerId")]
        public ulong ToSummonerId { get; set; }

        [JsonProperty("toSummonerName")]
        public string ToSummonerName { get; set; }
    }

    public class LocalMember
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public ulong BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public string BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public ulong SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public ulong TeamId { get; set; }
    }

    public class Member
    {
        [JsonProperty("allowedChangeActivity")]
        public bool AllowedChangeActivity { get; set; }

        [JsonProperty("allowedInviteOthers")]
        public bool AllowedInviteOthers { get; set; }

        [JsonProperty("allowedKickOthers")]
        public bool AllowedKickOthers { get; set; }

        [JsonProperty("allowedStartActivity")]
        public bool AllowedStartActivity { get; set; }

        [JsonProperty("allowedToggleInvite")]
        public bool AllowedToggleInvite { get; set; }

        [JsonProperty("autoFillEligible")]
        public bool AutoFillEligible { get; set; }

        [JsonProperty("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos { get; set; }

        [JsonProperty("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing { get; set; }

        [JsonProperty("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking { get; set; }

        [JsonProperty("botChampionId")]
        public ulong BotChampionId { get; set; }

        [JsonProperty("botDifficulty")]
        public string BotDifficulty { get; set; }

        [JsonProperty("botId")]
        public string BotId { get; set; }

        [JsonProperty("firstPositionPreference")]
        public string FirstPositionPreference { get; set; }

        [JsonProperty("isBot")]
        public bool IsBot { get; set; }

        [JsonProperty("isLeader")]
        public bool IsLeader { get; set; }

        [JsonProperty("isSpectator")]
        public bool IsSpectator { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("ready")]
        public bool Ready { get; set; }

        [JsonProperty("secondPositionPreference")]
        public string SecondPositionPreference { get; set; }

        [JsonProperty("showGhostedBanner")]
        public bool ShowGhostedBanner { get; set; }

        [JsonProperty("summonerIconId")]
        public ulong SummonerIconId { get; set; }

        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("summonerInternalName")]
        public string SummonerInternalName { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public ulong TeamId { get; set; }
    }

    public class RestrictionArgs
    {
    }

    public class Restriction
    {
        [JsonProperty("expiredTimestamp")]
        public int ExpiredTimestamp { get; set; }

        [JsonProperty("restrictionArgs")]
        public RestrictionArgs RestrictionArgs { get; set; }

        [JsonProperty("restrictionCode")]
        public string RestrictionCode { get; set; }

        [JsonProperty("summonerIds")]
        public List<ulong> SummonerIds { get; set; }

        [JsonProperty("summonerIdsString")]
        public string SummonerIdsString { get; set; }
    }

    public class Warning
    {
        [JsonProperty("expiredTimestamp")]
        public int ExpiredTimestamp { get; set; }

        [JsonProperty("restrictionArgs")]
        public RestrictionArgs RestrictionArgs { get; set; }

        [JsonProperty("restrictionCode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Restrictions RestrictionCode { get; set; }

        [JsonProperty("summonerIds")]
        public List<ulong> SummonerIds { get; set; }

        [JsonProperty("summonerIdsString")]
        public string SummonerIdsString { get; set; }
    }

    public class Party
    {
        [JsonProperty("canStartActivity")]
        public bool CanStartActivity { get; set; }

        [JsonProperty("chatRoomId")]
        public string ChatRoomId { get; set; }

        [JsonProperty("chatRoomKey")]
        public string ChatRoomKey { get; set; }

        [JsonProperty("gameConfig")]
        public GameConfig GameConfig { get; set; }

        [JsonProperty("invitations")]
        public List<Invitation> Invitations { get; set; }

        [JsonProperty("localMember")]
        public LocalMember LocalMember { get; set; }

        [JsonProperty("members")]
        public List<Member> Members { get; set; }

        [JsonProperty("partyId")]
        public string PartyId { get; set; }

        [JsonProperty("partyType")]
        public string PartyType { get; set; }

        [JsonProperty("restrictions")]
        public List<Restriction> Restrictions { get; set; }

        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; set; }
    }

    public enum SpectatorPolicy
    {
        NotAllowed,
        LobbyAllowed,
        FriendsAllowed,
        AllAllowed
    }

    public enum State
    {
        Requested,
        Pending,
        Accepted,
        Joined,
        Declined,
        Kicked,
        OnHold,
        Error
    }

    public enum BotDifficulty
    {
        NONE,
        EASY,
        MEDIUM,
        HARD,
        UBER,
        TUTORIAL,
        INTO
    }

    public enum Restrictions
    {
        QueueDisabled,
        QueueUnsupported,
        PlayerLevelRestriction,
        PlayerTimedRestriction,
        PlayerBannedRestriction,
        PlayerAvailableChampionRestriction,
        TeamDivisionRestriction,
        TeamMaxSizeRestriction,
        TeamMinSizeRestriction,
        PlayerBingeRestriction,
        PlayerDodgeRestriction,
        PlayerInGameRestriction,
        PlayerLeaverBustedRestriction,
        PlayerLeaverTaintedWarningRestriction,
        PlayerMaxLevelRestriction,
        PlayerMinLevelRestriction,
        PlayerMinorRestriction,
        PlayerTimePlayedRestriction,
        PlayerRankedSuspensionRestriction,
        TeamHighMMRMaxSizeRestriction,
        TeamSizeRestriction,
        PrerequisiteQueuesNotPlayedRestriction,
        GameVersionMismatch,
        GameVersionMissing,
        GameVersionNotSupported,
        QueueEntryNotEntitledRestriction,
        UnknownRestriction,
        BanInfoNotAvailable,
        MinorInfoNotAvailable,
        SummonerInfoNotAvailable,
        LeaguesInfoNotAvailable,
        InventoryChampsInfoNotAvailable,
        InventoryQueuesInfoNotAvailable,
        MmrStandardDeviationTooLarge
    }
}
