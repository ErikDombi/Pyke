using Pyke.ChampSelect.Models;
using Pyke.Events.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Pyke.ChampSelect
{
    public class ChampSelect : IChampSelect
    {
        private PykeAPI leagueAPI;

        public ChampSelect(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
        }

        public async Task<List<Champion>> GetChampionsAsync() => await leagueAPI.RequestHandler.StandardGet<List<Champion>>("/lol-champ-select/v1/all-grid-champions");

        public List<Champion> GetChampions() => GetChampionsAsync().GetAwaiter().GetResult();

        public async Task<List<Champ>> GetPickableChampionsAsync() {
            var response = await leagueAPI.RequestHandler.HttpRequest<List<long>>(HttpMethod.Get, "/lol-champ-select/v1/pickable-champion-ids", null);
            if (response.didFail) return null;
            return response.ParsedResponse.Select(c => leagueAPI.Champions.FirstOrDefault(t => t.Key == c)).ToList();
        }

        public List<Champ> GetPickableChampions() => GetPickableChampionsAsync().GetAwaiter().GetResult();

        public async Task<List<Champ>> GetBannableChampionsAsync() {
            var response = await leagueAPI.RequestHandler.HttpRequest<List<long>>(HttpMethod.Get, "/lol-champ-select/v1/bannable-champion-ids", null);
            if (response.didFail) return null;
            return response.ParsedResponse.Select(c => leagueAPI.Champions.FirstOrDefault(t => t.Key == c)).ToList();
        }
        public List<Champ> GetBannableChampions() => GetBannableChampionsAsync().GetAwaiter().GetResult();

        public async Task<Session> GetSessionAsync() => await leagueAPI.RequestHandler.StandardGet<Session>("/lol-champ-select/v1/session");

        public Session GetSession() => GetSessionAsync().GetAwaiter().GetResult();

        public async Task<bool> SetSessionActionAsync(int id, Models.Action action) => (await leagueAPI.RequestHandler.HttpRequest<Models.Action>(
                HttpMethod.Patch,
                $"/lol-champ-select/v1/session/actions/{id}",
                null,
                action
            )).didFail;

        public bool SetSessionAction(int id, Models.Action action) => SetSessionActionAsync(id, action).GetAwaiter().GetResult();

        public async Task<bool> SelectChampionAsync(string ChampionName, bool LockIn)
        {
            var champId = leagueAPI.Champions.FirstOrDefault(t => t.Name.ToLower() == ChampionName.ToLower()).Key;
            return await SelectChampionAsync(champId, LockIn);
        }

        public bool SelectChampion(string ChampionName, bool LockIn) => SelectChampionAsync(ChampionName, LockIn).GetAwaiter().GetResult();

        public async Task<bool> SelectChampionAsync(long ChampionId, bool LockIn)
        {
            try
            {
                var Session = await GetSessionAsync();
                var SummonerId = (await leagueAPI.Login.GetSessionAsync()).SummonerId;
                var ActorCellId = Session?.MyTeam?.FirstOrDefault(t => t.SummonerId == SummonerId)?.CellId;
                if (ActorCellId == null) return false;
                var myActions = Session.Actions.Select(t => t.FirstOrDefault(c => c.ActorCellId == ActorCellId));
                var Action = myActions?.FirstOrDefault(t => t != null && t.IsInProgress);
                Action.ChampionId = (int)leagueAPI.Champions.FirstOrDefault(t => t.Key == ChampionId).Key;
                Action.Completed = LockIn;
                return SetSessionAction(Action.Id, Action);
            }
            catch
            {
                return false;
            }
        }

        public bool SelectChampion(long ChampionId, bool LockIn) => SelectChampionAsync(ChampionId, LockIn).GetAwaiter().GetResult();

        public async Task<List<Trade>> GetTradesAsync() => await leagueAPI.RequestHandler.StandardGet<List<Trade>>("/lol-champ-select/v1/session/trades");

        public List<Trade> GetTrades() => GetTradesAsync().GetAwaiter().GetResult();

        public async Task<Trade> GetTradeByIdAsync(int id) => await leagueAPI.RequestHandler.StandardGet<Trade>($"/lol-chmap-select/v1/session/trades/{id}");

        public Trade GetTradeById(int id) => GetTradeByIdAsync(id).GetAwaiter().GetResult();

        public async Task AcceptTradeAsync(int id) => await leagueAPI.RequestHandler.StandardPost($"/lol-champ-select/v1/session/trades/{id}/accept");

        public void AcceptTrade(int id) => AcceptTradeAsync(id).GetAwaiter().GetResult();

        public async Task DeclineTradeAsync(int id) => await leagueAPI.RequestHandler.StandardPost($"/lol-champ-select/v1/session/trades/{id}/decline");

        public void DeclineTrade(int id) => DeclineTradeAsync(id).GetAwaiter().GetResult();

        public async Task RequestTradeAsync(int id) => await leagueAPI.RequestHandler.StandardPost($"/lol-champ-select/v1/session/trades/{id}/request");

        public void RequestTrade(int id) => RequestTradeAsync(id).GetAwaiter().GetResult();

        public async Task CancelTradeAsync(int id) => await leagueAPI.RequestHandler.StandardPost($"/lol-champ-select/v1/session/trades/{id}/cancel");

        public void CancelTrade(int id) => CancelTradeAsync(id).GetAwaiter().GetResult();

        public async Task<SummonerSlot> GetSummonerByCellIdAsync(int id) => await leagueAPI.RequestHandler.StandardGet<SummonerSlot>($"/lol-champ-select/v1/summoners/{id}");

        public SummonerSlot GetSummonerByCellId(int id) => GetSummonerByCellIdAsync(id).GetAwaiter().GetResult();

        public async Task<List<SummonerSlot>> GetRosterAsync()
        {
            List<SummonerSlot> allSummoners = new List<SummonerSlot>();
            Session session = await GetSessionAsync();
            if (session == null) return null;
            int gameSize = session.MyTeam.Count + session.TheirTeam.Count;
            for (int i = 0; i < gameSize; i++)
                allSummoners.Add(await GetSummonerByCellIdAsync(i));
            return allSummoners;
        }

        public List<SummonerSlot> GetRoster() => GetRosterAsync().GetAwaiter().GetResult();

        public async Task<List<SummonerSlot>> GetFriendlyRosterAsync() => (await GetRosterAsync())?.Where(t => t.IsOnPlayersTeam).ToList();

        public List<SummonerSlot> GetFriendlyRoster() => GetFriendlyRosterAsync().GetAwaiter().GetResult();

        public async Task<List<SummonerSlot>> GetEnemyRosterAsync() => (await GetRosterAsync())?.Where(t => !t.IsOnPlayersTeam).ToList();

        public List<SummonerSlot> GetEnemyRoster() => GetEnemyRosterAsync().GetAwaiter().GetResult();

        public async Task<PickableSkins> GetPickableSkinIdsAsync() => await leagueAPI.RequestHandler.StandardGet<PickableSkins>("/lol-champ-select/v1/pickable-skins");

        public PickableSkins GetPickableSkinIds() => GetPickableSkinIdsAsync().GetAwaiter().GetResult();

        public async Task UpdateSelectionAsync(Selection selection) => await leagueAPI.RequestHandler.HttpRequest<Selection, object>(HttpMethod.Patch, "/lol-champ-select/v1/session/my-selection", null, selection);

        public void UpdateSelection(Selection selection) => UpdateSelectionAsync(selection).GetAwaiter().GetResult();

        public async Task SelectSummonerSpellsAsync(Spell Left, Spell Right)
        {
            Selection selection = new Selection()
            {
                spell1Id = (ulong)Left,
                spell2Id = (ulong)Right
            };
            await UpdateSelectionAsync(selection);
        }

        public void SelectSummonerSpells(Spell Left, Spell Right) => SelectSummonerSpellsAsync(Left, Right).GetAwaiter().GetResult();
    }
}