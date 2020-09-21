using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.ChampSelect.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public partial class Bans
    {
        [JsonProperty("myTeamBans")]
        public List<int> MyTeamBans;

        [JsonProperty("numBans")]
        public long NumBans;

        [JsonProperty("theirTeamBans")]
        public List<int> TheirTeamBans;
    }

    public partial class ChatDetails
    {
        [JsonProperty("chatRoomName")]
        public string ChatRoomName;

        [JsonProperty("chatRoomPassword")]
        public string ChatRoomPassword;
    }

    public partial class EntitledFeatureState
    {
        [JsonProperty("additionalRerolls")]
        public long AdditionalRerolls;

        [JsonProperty("unlockedSkinIds")]
        public List<int> UnlockedSkinIds;
    }

    public partial class Player
    {
        [JsonProperty("assignedPosition")]
        public string AssignedPosition;

        [JsonProperty("cellId")]
        public long CellId;

        [JsonProperty("championId")]
        public long ChampionId;

        [JsonProperty("championPickIntent")]
        public long ChampionPickIntent;

        [JsonProperty("entitledFeatureType")]
        public string EntitledFeatureType;

        [JsonProperty("selectedSkinId")]
        public long SelectedSkinId;

        [JsonProperty("spell1Id")]
        public ulong Spell1Id;

        [JsonProperty("spell2Id")]
        public ulong Spell2Id;

        [JsonProperty("summonerId")]
        public long SummonerId;

        [JsonProperty("team")]
        public long Team;

        [JsonProperty("wardSkinId")]
        public long WardSkinId;
    }

    public partial class Timer
    {
        [JsonProperty("adjustedTimeLeftInPhase")]
        public long AdjustedTimeLeftInPhase;

        [JsonProperty("longernalNowInEpochMs")]
        public long longernalNowInEpochMs;

        [JsonProperty("isInfinite")]
        public bool IsInfinite;

        [JsonProperty("phase")]
        public string Phase;

        [JsonProperty("totalTimeInPhase")]
        public long TotalTimeInPhase;
    }

    public partial class Action
    {
        [JsonProperty("actorCellId")]
        public int ActorCellId;
        [JsonProperty("championId")]
        public long ChampionId;
        [JsonProperty("completed")]
        public bool Completed;
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("isAllyAction")]
        public bool IsAllyAction;
        [JsonProperty("isInProgress")]
        public bool IsInProgress;
        [JsonProperty("pickTurn")]
        public long PickTurn;
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SessionActionType Type;
    }

    public partial class Session
    {
        [JsonProperty("actions")]
        public List<List<Action>> Actions;

        [JsonProperty("allowBattleBoost")]
        public bool AllowBattleBoost;

        [JsonProperty("allowDuplicatePicks")]
        public bool AllowDuplicatePicks;

        [JsonProperty("allowLockedEvents")]
        public bool AllowLockedEvents;

        [JsonProperty("allowRerolling")]
        public bool AllowRerolling;

        [JsonProperty("allowSkinSelection")]
        public bool AllowSkinSelection;

        [JsonProperty("bans")]
        public Bans Bans;

        [JsonProperty("benchChampionIds")]
        public List<int> BenchChampionIds;

        [JsonProperty("benchEnabled")]
        public bool BenchEnabled;

        [JsonProperty("boostableSkinCount")]
        public long BoostableSkinCount;

        [JsonProperty("chatDetails")]
        public ChatDetails ChatDetails;

        [JsonProperty("counter")]
        public long Counter;

        [JsonProperty("entitledFeatureState")]
        public EntitledFeatureState EntitledFeatureState;

        [JsonProperty("gameId")]
        public ulong GameId;

        [JsonProperty("hasSimultaneousBans")]
        public bool HasSimultaneousBans;

        [JsonProperty("hasSimultaneousPicks")]
        public bool HasSimultaneousPicks;

        [JsonProperty("isCustomGame")]
        public bool IsCustomGame;

        [JsonProperty("isSpectating")]
        public bool IsSpectating;

        [JsonProperty("localPlayerCellId")]
        public long LocalPlayerCellId;

        [JsonProperty("lockedEventIndex")]
        public long LockedEventIndex;

        [JsonProperty("myTeam")]
        public List<Player> MyTeam;

        [JsonProperty("rerollsRemaining")]
        public long RerollsRemaining;

        [JsonProperty("skipChampionSelect")]
        public bool SkipChampionSelect;

        [JsonProperty("theirTeam")]
        public List<Player> TheirTeam;

        [JsonProperty("timer")]
        public Timer Timer;

        [JsonProperty("trades")]
        public List<Events.Models.Trade> Trades;
    }

    public enum SessionTradeState
    {
        AVAILABLE, BUSY, INVALID
    }
     
    // TODO: Verify these are correct
    public enum SessionActionType
    {
        Pick,
        Ban,
        phase_transition
    }
}
