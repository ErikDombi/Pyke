using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Gameflow.Models
{
    public class CurrentLobbyStatus
    {
        public bool allowedPlayAgain { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerStatusCustomSpectatorPolicy customSpectatorPolicy { get; set; }
        public List<int> invitedSummonerIds { get; set; }
        public bool isCustom { get; set; }
        public bool isLeader { get; set; }
        public bool isPracticeTool { get; set; }
        public bool isSpectator { get; set; }
        public string lobbyId { get; set; }
        public List<int> memberSummonerIds { get; set; }
        public int queueId { get; set; }
    }

    public class LastQueuedLobbyStatus
    {
        public bool allowedPlayAgain { get; set; }
        public string customSpectatorPolicy { get; set; }
        public List<int> invitedSummonerIds { get; set; }
        public bool isCustom { get; set; }
        public bool isLeader { get; set; }
        public bool isPracticeTool { get; set; }
        public bool isSpectator { get; set; }
        public string lobbyId { get; set; }
        public List<int> memberSummonerIds { get; set; }
        public int queueId { get; set; }
    }

    public class PlayerStatus
    {
        public bool canInviteOthersAtEog { get; set; }
        public CurrentLobbyStatus currentLobbyStatus { get; set; }
        public LastQueuedLobbyStatus lastQueuedLobbyStatus { get; set; }
    }

    public enum PlayerStatusCustomSpectatorPolicy
    {
        NotAllowed,
        LobbyAllowed,
        FriendsAllowed,
        AllAllowed
    }
}
