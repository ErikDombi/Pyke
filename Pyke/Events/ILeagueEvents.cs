 using System;
using System.Collections.Generic;
using System.Text;
using Pyke.ChampSelect.Models;
using Pyke.Events.Models;
using Pyke.Lobby.Models.Party;
using Pyke.Matchmaking;

namespace Pyke.Events
{
    public interface ILeagueEvents
    {
        public event EventHandler<State> GameflowStateChanged;

        public event EventHandler<ReadyState> OnReadyStateChanged;

        public event EventHandler<Champ> SelectedChampionChanged;

        public event EventHandler<List<Trade>> ChampionTradesUpdated;

        public event EventHandler<SessionActionType> OnChampSelectTurnToPick;

        public event EventHandler<QueueInfo> MatchmakingUpdated;

        public event EventHandler<Party> PartyUpdated;

        /// <summary>
        /// Is invoked when any changes occur during champ select. You should update all champ select data when this is invoked.
        /// </summary>
        public event EventHandler<Session> OnSessionUpdated;

        event EventHandler<SummonerSelection> OtherSummonerSelectionUpdated;

        public void SubscribeEvent(EventType Event);

        public void UnsubscribeEvent(EventType Event);

        public void UnsubscribeAllEvents();

        public void SubscribeAllEvents();

        public enum EventType
        {
            GameflowStateChanged,
            MatchFoundStatusChanged,
            SelectedChampionChanged,
            ChampionTradeRecieved,
            OnSessionUpdated,
            OnChampSelectTurnToPick,
            MatchmakingUpdated,
            OtherSummonerSelectionUpdated,
            PartyUpdated
        }
    }
}
