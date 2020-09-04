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
        private PykeAPI leagueAPI;

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

        private bool shouldNotifyPickBan = true;
        private bool shouldNotifyPickSelection = true;
        private int actionId = 0;

        public LeagueEvents(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
            _GameflowStateChanged += (s, e) =>
            {
                try
                {
                    var state = StateChanged.ParseState(e.Data.ToString());
                    leagueAPI.logger.Verbose("Invoked GameflowStateChanged: " + state.ToString());
                    GameflowStateChanged?.Invoke(s, state);
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking GameflowStateChanged Event.\n" + ex.ToString());
                }
            };
            _MatchFoundStatusChanged += (s, e) =>
            {
                try
                {
                    leagueAPI.logger.Verbose("Invoked OnMatchFound");
                    OnMatchFound?.Invoke(s, JsonConvert.DeserializeObject<ReadyState>(e.Data.ToString()));
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking MatchFoundStatusChanged Event.\n" + ex.ToString());
                }
            };
            _SelectedChampionChanged += (s, e) =>
            {
                try
                {
                    var champ = leagueAPI.Champions.FirstOrDefault(t => t.Key == long.Parse(e.Data.ToString()));
                    if (champ == null) return;
                    leagueAPI.logger.Verbose("Invoked SelectedChampionChanged with Champion: " + champ.Name);
                    SelectedChampionChanged?.Invoke(s, champ);
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking SelectedChampionChanged Event.\n" + ex.ToString());
                }
            };
            _ChampionTradeRecieved += (s, e) =>
            {
                try
                {
                    leagueAPI.logger.Verbose("Invoked ChampionTradesUpdated");
                    ChampionTradesUpdated?.Invoke(s, JsonConvert.DeserializeObject<List<Trade>>(e.Data.ToString()));
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking ChampionTradeRecieved Event.\n" + ex.ToString());
                }
            };
            _OnSessionUpdated += (s, e) =>
            {
                try
                {
                    var session = JsonConvert.DeserializeObject<Session>(e.Data.ToString());
                    leagueAPI.logger.Verbose("Invoked OnSessionUpdated");
                    OnSessionUpdated?.Invoke(s, session);
                    var SummonerId = leagueAPI.Login.GetSession().SummonerId;
                    var ActorCellId = session.MyTeam.FirstOrDefault(t => t.SummonerId == SummonerId)?.CellId;
                    if (session.Actions.Count == 0)
                        return;
                    var myActions = session.Actions.Select(t => t.FirstOrDefault(c => c.ActorCellId == ActorCellId));
                    var Action = myActions?.FirstOrDefault(t => t.IsInProgress);
                    if (Action == null) return;
                    if(Action.Id != actionId)
                    {
                        shouldNotifyPickBan = true;
                        shouldNotifyPickSelection = true;
                        actionId = Action.Id;
                    }
                    if(Action.IsInProgress)
                    {
                        PickType type = Enum.Parse<PickType>(Action.Type, true);
                        if ((shouldNotifyPickBan && type == PickType.Ban) || (shouldNotifyPickSelection && type == PickType.Pick))
                        {
                            leagueAPI.logger.Verbose("Invoked OnChampSelectTurnToPick with type: " + type);
                            OnChampSelectTurnToPick?.Invoke(s, type);
                        }
                        if (Action.Type == "pick")
                            shouldNotifyPickSelection = false;
                        if (Action.Type == "ban")
                            shouldNotifyPickBan = false;
                    }
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking OnSessionUpdated Event.\n" + ex.ToString());
                    leagueAPI.logger.Debug("  ----------------- DEBUG DATA -------------");
                    leagueAPI.logger.Debug(e.Data.ToString());
                    leagueAPI.logger.Debug("----------------- END DEBUG DATA -------------");
                }
            };
        }

        public void SubscribeEvent(EventType Event)
        {
            leagueAPI.logger.Information("Subscribed Event: " + Event.ToString());

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
            leagueAPI.logger.Information("Unsubscribed Event: " + Event.ToString());

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
