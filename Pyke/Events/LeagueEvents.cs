using Pyke.ChampSelect.Models;
using Pyke.Events.Models;
using Pyke.Websocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Pyke.Events.ILeagueEvents;
using System.Threading;
using Pyke.Matchmaking;
using Pyke.Lobby.Models.Party;

namespace Pyke.Events
{
    public class LeagueEvents : ILeagueEvents
    {
        private PykeAPI leagueAPI;

        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        // Private Events
        private event EventHandler<LeagueEvent> _GameflowStateChanged;
        private event EventHandler<LeagueEvent> _MatchFoundStatusChanged;
        private event EventHandler<LeagueEvent> _SelectedChampionChanged;
        private event EventHandler<LeagueEvent> _ChampionTradeRecieved;
        private event EventHandler<LeagueEvent> _OnSessionUpdated;
        private event EventHandler<LeagueEvent> _MatchMakingUpdated;
        private event EventHandler<LeagueEvent> _PartyUpdated;

        //Public Events
        public event EventHandler<State> GameflowStateChanged;
        public event EventHandler<ReadyState> OnReadyStateChanged;
        public event EventHandler<Champ> SelectedChampionChanged;
        public event EventHandler<List<Trade>> ChampionTradesUpdated;
        /// <inheritdoc/>
        public event EventHandler<Session> OnSessionUpdated;
        public event EventHandler<SessionActionType> OnChampSelectTurnToPick;
        public event EventHandler<SummonerSelection> OtherSummonerSelectionUpdated;
        public event EventHandler<QueueInfo> MatchmakingUpdated;
        public event EventHandler<Party> PartyUpdated;

        private bool shouldNotifyPickBan = true;
        private bool shouldNotifyPickSelection = true;
        private ulong actionId = 0;

        private Session oldSession;

        public LeagueEvents(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
            _GameflowStateChanged += (s, e) =>
            {
                try
                {
                    var state = StateChanged.ParseState(e.Data.ToString());
                    leagueAPI.logger.Verbose("Invoked GameflowStateChanged: " + state.ToString(), JsonSettings);
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
                    ReadyState state = JsonConvert.DeserializeObject<ReadyState>(e.Data.ToString(), JsonSettings);
                    if (state != null)
                        OnReadyStateChanged?.Invoke(s, state);
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
                    ChampionTradesUpdated?.Invoke(s, JsonConvert.DeserializeObject<List<Trade>>(e.Data.ToString(), JsonSettings));
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
                    var session = JsonConvert.DeserializeObject<Session>(e.Data.ToString(), JsonSettings);
                    leagueAPI.logger.Verbose("Invoked OnSessionUpdated");
                    OnSessionUpdated?.Invoke(s, session);
                    CheckOnChampSelect(s, session);
                    CheckOtherUpdatedChamp(s, session);
                    oldSession = session;
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking OnSessionUpdated Event.\n" + ex.ToString());
                    leagueAPI.logger.Debug("  ----------------- DEBUG DATA -------------");
                    leagueAPI.logger.Debug(e.Data.ToString());
                    leagueAPI.logger.Debug("----------------- END DEBUG DATA -------------");
                }
            };
            _MatchMakingUpdated += (s, e) =>
            {
                try
                {
                    QueueInfo _info = JsonConvert.DeserializeObject<QueueInfo>(e.Data.ToString(), JsonSettings);
                    MatchmakingUpdated?.Invoke(this, _info);
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking MatchMakingUpdated Event.\n" + ex.ToString());
                }
            };
            _PartyUpdated += (s, e) =>
            {
                try
                {
                    if (e == null)
                        return;
                    Party _party = JsonConvert.DeserializeObject<Party>(e.Data.ToString(), JsonSettings);
                    if(_party == null)
                        return;
                    PartyUpdated?.Invoke(this, _party);
                }
                catch (Exception ex)
                {
                    leagueAPI.logger.Error("An exception occured while invoking PartyUpdated Event.\n" + ex.ToString());
                }
            };
        }

        private void CheckOtherUpdatedChamp(object s, Session session)
        {
            if (oldSession == null || session == null) return;
            // Store old session, compare if actions are different, if so, find which one and return it
            if (session.Actions.Count != oldSession.Actions.Count)
                return;
            var currentNewActions = session.Actions.LastOrDefault();
            var currentOldActions = oldSession.Actions.LastOrDefault();
            if (currentNewActions == null || currentOldActions == null)
                return;
            for(int i = 0; i < currentNewActions.Count; i++)
            {
                if(JsonConvert.SerializeObject(currentNewActions[i], JsonSettings) != JsonConvert.SerializeObject(currentOldActions[i], JsonSettings))
                {
                    var action = currentNewActions[i];
                    var players = leagueAPI.ChampSelect.GetRoster();
                    var currentPlayer = players.FirstOrDefault(t => t.CellId == action.ActorCellId);
                    var summonerSelection = new SummonerSelection() { SelectionInfo = action, SummonerInfo = currentPlayer };
                    OtherSummonerSelectionUpdated?.Invoke(s, summonerSelection);
                }
            }
        }

        private void CheckOnChampSelect(object s, Session session)
        {
            try
            {
                var SummonerId = leagueAPI.Login.GetSession()?.SummonerId;
                if (SummonerId == null) return;
                var ActorCellId = session.MyTeam.FirstOrDefault(t => t.SummonerId == SummonerId)?.CellId;
                if (session.Actions.Count == 0)
                    return;
                var myActions = session.Actions.Select(t => t.FirstOrDefault(c => c.ActorCellId == ActorCellId));
                var Action = myActions?.FirstOrDefault(t => t != null && t.IsInProgress);
                if (Action == null) return;
                if (Action.Id != actionId)
                {
                    shouldNotifyPickBan = true;
                    shouldNotifyPickSelection = true;
                    actionId = Action.Id;
                }
                if (Action.IsInProgress)
                {
                    SessionActionType type = Action.Type;
                    if ((shouldNotifyPickBan && type == SessionActionType.Ban) || (shouldNotifyPickSelection && type == SessionActionType.Pick))
                    {
                        leagueAPI.logger.Verbose("Invoked OnChampSelectTurnToPick with type: " + type);
                        OnChampSelectTurnToPick?.Invoke(s, type);
                    }
                    if (Action.Type == SessionActionType.Pick)
                        shouldNotifyPickSelection = false;
                    if (Action.Type == SessionActionType.Ban)
                        shouldNotifyPickBan = false;
                }
            }
            catch
            {
                leagueAPI.logger.Error("");
            }
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
                case EventType.OnChampSelectTurnToPick:
                case EventType.OnSessionUpdated:
                case EventType.OtherSummonerSelectionUpdated:
                    leagueAPI.EventHandler.Subscribe("/lol-champ-select/v1/session", _OnSessionUpdated);
                    break;
                case EventType.MatchmakingUpdated:
                    leagueAPI.EventHandler.Subscribe("/lol-matchmaking/v1/search", _MatchMakingUpdated);
                    break;
                case EventType.PartyUpdated:
                    leagueAPI.EventHandler.Subscribe("/lol-lobby/v2/lobby", _PartyUpdated);
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
                case EventType.OnChampSelectTurnToPick:
                case EventType.OtherSummonerSelectionUpdated:
                    leagueAPI.EventHandler.Unsubscribe("/lol-champ-select/v1/session");
                    break;
                case EventType.MatchmakingUpdated:
                    leagueAPI.EventHandler.Unsubscribe("/lol-matchmaking/v1/search");
                    break;
                case EventType.PartyUpdated:
                    leagueAPI.EventHandler.Unsubscribe("/lol-lobby/v2/lobby");
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
