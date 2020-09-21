using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.ChampSelect.Models
{
    public class SummonerSlot
    {
        [JsonProperty("actingBackgroundAnimationState")]
        public string ActingBackgroundAnimationState;

        [JsonProperty("activeActionType")]
        public string ActiveActionType;

        [JsonProperty("areSummonerActionsComplete")]
        public bool AreSummonerActionsComplete;

        [JsonProperty("assignedPosition")]
        public string AssignedPosition;

        [JsonProperty("banIntentSquarePortratPath")]
        public string BanIntentSquarePortratPath;

        [JsonProperty("cellId")]
        public ulong CellId;

        [JsonProperty("championIconStyle")]
        public string ChampionIconStyle;

        [JsonProperty("championName")]
        public string ChampionName;

        [JsonProperty("currentChampionVotePercentInteger")]
        public int CurrentChampionVotePercentInteger;

        [JsonProperty("entitledFeatureType")]
        public string EntitledFeatureType;

        [JsonProperty("isActingNow")]
        public bool IsActingNow;

        [JsonProperty("isDonePicking")]
        public bool IsDonePicking;

        [JsonProperty("isOnPlayersTeam")]
        public bool IsOnPlayersTeam;

        [JsonProperty("isPickIntenting")]
        public bool IsPickIntenting;

        [JsonProperty("isPlaceholder")]
        public bool IsPlaceholder;

        [JsonProperty("isSelf")]
        public bool IsSelf;

        [JsonProperty("pickSnipedClass")]
        public string PickSnipedClass;

        [JsonProperty("shouldShowActingBar")]
        public bool ShouldShowActingBar;

        [JsonProperty("shouldShowBanIntentIcon")]
        public bool ShouldShowBanIntentIcon;

        [JsonProperty("shouldShowExpanded")]
        public bool ShouldShowExpanded;

        [JsonProperty("shouldShowRingAnimations")]
        public bool ShouldShowRingAnimations;

        [JsonProperty("shouldShowSelectedSkin")]
        public bool ShouldShowSelectedSkin;

        [JsonProperty("shouldShowSpells")]
        public bool ShouldShowSpells;

        [JsonProperty("showMuted")]
        public bool ShowMuted;

        [JsonProperty("showTrades")]
        public bool ShowTrades;

        [JsonProperty("skinId")]
        public ulong SkinId;

        [JsonProperty("skinSplashPath")]
        public string SkinSplashPath;

        [JsonProperty("slotId")]
        public ulong SlotId;

        [JsonProperty("spell1IconPath")]
        public string Spell1IconPath;

        [JsonProperty("spell2IconPath")]
        public string Spell2IconPath;

        [JsonProperty("statusMessageKey")]
        public string StatusMessageKey;

        [JsonProperty("summonerId")]
        public ulong SummonerId;

        [JsonProperty("tradeId")]
        public ulong TradeId;
    }
}
