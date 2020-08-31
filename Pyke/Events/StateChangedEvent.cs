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
        ReadyCheck,
        ChampSelect,
        InProgress,
        PostGameSummary
    }
}
