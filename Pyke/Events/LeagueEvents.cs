using Pyke.ChampSelect.Models;
using Pyke.Events.Models;
using Pyke.Websocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Pyke.Events.ILeagueEvents;

namespace Pyke.Events
{
    public class LeagueEvents : ILeagueEvents
    {
        private LeagueAPI leagueAPI;

        // Private Events
        private event EventHandler<LeagueEvent> _GameflowStateChanged;
        private event EventHandler<LeagueEvent> _MatchFoundStatusChanged;
        private event EventHandler<LeagueEvent> _SelectedChampionChanged;
        private event EventHandler<LeagueEvent> _ChampionTradeRecieved;
        private event EventHandler<LeagueEvent> _OnSessionUpdated;

        //Public Events
        public event EventHandler<State> GameflowStateChanged;
        public event EventHandler<ReadyState> OnMatchFound;
        public event EventHandler<Champ> SelectedChampionChanged;
        public event EventHandler<List<Trade>> ChampionTradesUpdated;
        /// <inheritdoc/>
        public event EventHandler<Session> OnSessionUpdated;
        public event EventHandler<PickType> OnChampSelectTurnToPick;

        public LeagueEvents(LeagueAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
            _GameflowStateChanged += (s, e) =>
            {
                try
                {
                    GameflowStateChanged?.Invoke(s, StateChanged.ParseState(e.Data.ToString()));
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("[ERROR] An exception occured while invoking GameflowStateChanged Event.\n" + ex.ToString());
#endif
                }
            };
            _MatchFoundStatusChanged += (s, e) =>
            {
                try
                {
                    OnMatchFound?.Invoke(s, JsonConvert.DeserializeObject<ReadyState>(e.Data.ToString()));
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("[ERROR] An exception occured while invoking MatchFoundStatusChanged Event.\n" + ex.ToString());
#endif
                }
            };
            _SelectedChampionChanged += (s, e) =>
            {
                try
                {
                    SelectedChampionChanged?.Invoke(s, leagueAPI.Champions.FirstOrDefault(t => t.Key == long.Parse(e.Data.ToString())));
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("[ERROR] An exception occured while invoking SelectedChampionChanged Event.\n" + ex.ToString());
#endif
                }
            };
            _ChampionTradeRecieved += (s, e) =>
            {
                try
                {
                    ChampionTradesUpdated?.Invoke(s, JsonConvert.DeserializeObject<List<Trade>>(e.Data.ToString()));
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("[ERROR] An exception occured while invoking ChampionTradeRecieved Event.\n" + ex.ToString());
#endif
                }
            };
            _OnSessionUpdated += (s, e) =>
            {
                try
                {
                    var session = JsonConvert.DeserializeObject<Session>(e.Data.ToString());
                    OnSessionUpdated?.Invoke(s, session);
                    var SummonerId = leagueAPI.Login.GetSession().SummonerId;
                    var ActorCellId = session.MyTeam.FirstOrDefault(t => t.SummonerId == SummonerId).CellId;
                    var Action = session.Actions[0].FirstOrDefault(t => t.ActorCellId == ActorCellId);
                    if(Action.IsInProgress)
                    {
                        OnChampSelectTurnToPick?.Invoke(s, Enum.Parse(typeof(PickType), Action.Type));
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("[ERROR] An exception occured while invoking OnSessionUpdated Event.\n" + ex.ToString());
#endif
                }
            };
        }

        public void SubscribeEvent(EventType Event)
        {
#if DEBUG
            Console.WriteLine("[DEBUG] Subscribed Event: " + Event.ToString());
#endif

            switch (Event)
            {
                case EventType.GameflowStateChanged:
                    leagueAPI.EventHandler.Subscribe("/lol-gameflow/v1/gameflow-phase", _GameflowStateChanged);
                    break;
                case EventType.MatchFoundStatusChanged:
                    leagueAPI.EventHandler.Subscribe("/lol-matchmaking/v1/ready-check", _MatchFoundStatusChanged);
                    break;
                case EventType.SelectedChampionChanged:
                    leagueAPI.EventHandler.Subscribe("/lol-champ-select/v1/current-champion", _SelectedChampionChanged);
                    break;
                case EventType.ChampionTradeRecieved:
                    leagueAPI.EventHandler.Subscribe("/lol-champ-select/v1/session/trades", _ChampionTradeRecieved);
                    break;
                case EventType.OnChampSelectTurn:
                case EventType.OnSessionUpdated:
                    leagueAPI.EventHandler.Subscribe("/lol-champ-select/v1/session", _OnSessionUpdated);
                    break;
            }
        }

        public void UnsubscribeEvent(EventType Event)
        {
#if DEBUG
            Console.WriteLine("[DEBUG] Subscribed Event: " + Event.ToString());
#endif

            switch (Event)
            {
                case EventType.GameflowStateChanged:
                    leagueAPI.EventHandler.Unsubscribe("/lol-gameflow/v1/gameflow-phase");
                    break;
                case EventType.MatchFoundStatusChanged:
                    leagueAPI.EventHandler.Unsubscribe("/lol-matchmaking/v1/ready-check");
                    break;
                case EventType.SelectedChampionChanged:
                    leagueAPI.EventHandler.Unsubscribe("/lol-champ-select/v1/current-champion");
                    break;
                case EventType.ChampionTradeRecieved:
                    leagueAPI.EventHandler.Unsubscribe("/lol-champ/select/v1/session/trades");
                    break;
                case EventType.OnSessionUpdated:
                case EventType.OnChampSelectTurn:
                    leagueAPI.EventHandler.Unsubscribe("/lol-champ-select/v1/session");
                    break;
            }
        }

        public void UnsubscribeAllEvents() => leagueAPI.EventHandler.UnsubscribeAll();

        public void SubscribeAllEvents()
        {
            foreach (EventType eventType in (EventType[])Enum.GetValues(typeof(EventType)))
                SubscribeEvent(eventType);
        }
    }
}
