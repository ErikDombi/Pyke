using Pyke.ChampSelect.Models;
using Pyke.Events.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.ChampSelect
{
    public interface IChampSelect
    {
        public Task<List<Champion>> GetChampionsAsync();

        public List<Champion> GetChampions();

        public Task<List<Champion>> GetPickableChampionsAsync();

        public Task<List<Champ>> GetBannableChampionsAsync();

        public List<Champ> GetBannableChampions();

        public Task<Session> GetSessionAsync();

        public Session GetSession();

        public Task SetSessionActionAsync(int id, Models.Action action);

        public void SetSessionAction(int id, Models.Action action);

        public Task SelectChampionAsync(string ChampionName, bool LockIn);

        public void SelectChampion(string ChampionName, bool LockIn);

        public Task SelectChampionAsync(long ChampionId, bool LockIn);

        public void SelectChampion(long ChampionId, bool LockIn);

        public Task<List<Trade>> GetTradesAsync();

        public List<Trade> GetTrades();

        public Task<Trade> GetTradeByIdAsync(int id);

        public Trade GetTradeById(int id);

        public Task AcceptTradeAsync(int id);

        public void AcceptTrade(int id);

        public Task DeclineTradeAsync(int id);

        public void DeclineTrade(int id);

        public Task RequestTradeAsync(int id);

        public void RequestTrade(int id);

        public Task CancelTradeAsync(int id);

        public void CancelTrade(int id);

        public Task<SummonerSlot> GetSummonerByCellIdAsync(int id);

        public SummonerSlot GetSummonerByCellId(int id);

        public async Task<List<SummonerSlot>> GetRosterAsync()
        {
            List<SummonerSlot> allSummoners = new List<SummonerSlot>();
            Session session = await GetSessionAsync();
            int gameSize = session.MyTeam.Count + session.TheirTeam.Count;
            for (int i = 0; i < gameSize; i++)
                allSummoners.Add(await GetSummonerByCellIdAsync(i));
            return allSummoners;
        }

        public List<SummonerSlot> GetRoster();

        public Task<List<SummonerSlot>> GetFriendlyRosterAsync();

        public List<SummonerSlot> GetFriendlyRoster();

        public Task<List<SummonerSlot>> GetEnemyRosterAsync();

        public List<SummonerSlot> GetEnemyRoster();
    }
}
