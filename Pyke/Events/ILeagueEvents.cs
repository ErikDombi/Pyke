 using System;
using System.Collections.Generic;
using System.Text;
using Pyke.ChampSelect.Models;
using Pyke.Events.Models;

namespace Pyke.Events
{
    public interface ILeagueEvents
    {
        public event EventHandler<State> GameflowStateChanged;

        public event EventHandler<ReadyState> OnMatchFound;

        public event EventHandler<Champ> SelectedChampionChanged;

        public event EventHandler<List<Trade>> ChampionTradesUpdated;

        event EventHandler<PickType> OnChampSelectTurnToPick;

        /// <summary>
        /// Is invoked when any changes occur during champ select. You should update all champ select data when this is invoked.
        /// </summary>
        public event EventHandler<Session> OnSessionUpdated;

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
            OnChampSelectTurn
        }
    }
}
