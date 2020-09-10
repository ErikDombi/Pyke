using Pyke.Websocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Events
{
    public class StateChanged
    {

        public static State ParseState(string State)
        {
            switch (State) {
                case "ChampSelect":
                    return Events.State.ChampSelect;
                case "Lobby":
                    return Events.State.Lobby;
                case "InProgress":
                    return Events.State.InProgress;
                case "Matchmaking":
                    return Events.State.MatchMaking;
                case "EndOfGame":
                    return Events.State.PostGameSummary;
                case "ReadyCheck":
                    return Events.State.ReadyCheck;
                case "CheckedIntoTournament":
                    return Events.State.CheckedIntoTournament;
                case "GameStart":
                    return Events.State.GameStart;
                case "FailedToLaunch":
                    return Events.State.FailedToLaunch;
                case "WaitingForStats":
                    return Events.State.WaitingForStats;
                case "PostGameSummary":
                    return Events.State.PostGameSummary;
                case "PreEndOfGame":
                    return Events.State.PreEndOfGame;
                case "TerminatedInError":
                    return Events.State.TerminatedInError;
                case "Reconnect":
                    return Events.State.Reconnect;
                default:
                    return Events.State.None;
            }
        }
    }
    public enum State
    {
        None,
        Lobby,
        MatchMaking,
        CheckedIntoTournament,
        ReadyCheck,
        ChampSelect,
        GameStart,
        FailedToLaunch,
        InProgress,
        PostGameSummary,
        WaitingForStats,
        PreEndOfGame,
        EndOfGame,
        TerminatedInError,
        Reconnect
    }
}
