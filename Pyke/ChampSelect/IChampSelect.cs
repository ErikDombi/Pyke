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
        /// <summary>
        /// Get a list of all champions in Champ Select
        /// Endpoint: /lol-champ-select/v1/all-grid-champions
        /// </summary>
        /// <returns><see cref="List{Champion}"/></returns>
        Task<List<Champion>> GetChampionsAsync();

        /// <summary>
        /// Get a list of all champions in Champ Select
        /// Endpoint: /lol-champ-select/v1/all-grid-champions
        /// </summary>
        /// <returns><see cref="List{Champion}"/></returns>
        List<Champion> GetChampions();

        /// <summary>
        /// Get a list of all pickable champions in Champ Select
        /// Endpoint: /lol-champ-select/v1/pickable-champion-ids
        /// </summary>
        /// <returns><see cref="List{Champion}"/></returns>
        Task<List<Champion>> GetPickableChampionsAsync();
        // TODO: Rewrite to use /lol-champ-select/v1/pickable-champion-ids

        /// <summary>
        /// Get a list of all pickable champions in Champ Select
        /// </summary>
        /// <returns><see cref="List{Champion}"/></returns>
        List<Champion> GetPickableChampions();

        /// <summary>
        /// Get a list of all bannable champions in Champ Select
        /// Endpoint: /lol-champ-select/v1/bannable-champion-ids
        /// </summary>
        /// <returns><see cref="List{Champ}"/></returns>
        Task<List<Champ>> GetBannableChampionsAsync();

        /// <summary>
        /// Get a list of all bannable champions in Champ Select
        /// Endpoint: /lol-champ-select/v1/bannable-champion-ids
        /// </summary>
        /// <returns><see cref="List{Champ}"/></returns>
        List<Champ> GetBannableChampions();

        /// <summary>
        /// Returns the current champion select session
        /// Endpoint: /lol-champ-select/v1/session
        /// </summary>
        /// <returns><see cref="Session"/></returns>
        Task<Session> GetSessionAsync();

        /// <summary>
        /// Returns the current champion select session
        /// Endpoint: /lol-champ-select/v1/session
        /// </summary>
        /// <returns><see cref="Session"/></returns>
        Session GetSession();

        Task SetSessionActionAsync(int id, Models.Action action);

        void SetSessionAction(int id, Models.Action action);

        Task SelectChampionAsync(string ChampionName, bool LockIn);

        void SelectChampion(string ChampionName, bool LockIn);

        Task<List<Trade>> GetTradesAsync();

        List<Trade> GetTrades();

        Task<Trade> GetTradeByIdAsync(int id);

        Trade GetTradeById(int id);

        Task AcceptTradeAsync(int id);

        void AcceptTrade(int id);

        Task DeclineTradeAsync(int id);

        void DeclineTrade(int id);

        Task RequestTradeAsync(int id);

        void RequestTrade(int id);

        Task CancelTradeAsync(int id);

        void CancelTrade(int id);

        Task<SummonerSlot> GetSummonerByCellIdAsync(int id);

        SummonerSlot GetSummonerByCellId(int id);

        Task<List<SummonerSlot>> GetRosterAsync();

        List<SummonerSlot> GetRoster();

        Task<List<SummonerSlot>> GetFriendlyRosterAsync();

        List<SummonerSlot> GetFriendlyRoster();

        Task<List<SummonerSlot>> GetEnemyRosterAsync();

        List<SummonerSlot> GetEnemyRoster();

        Task<PickableSkins> GetPickableSkinIdsAsync();

        PickableSkins GetPickableSkinIds() => GetPickableSkinIdsAsync().GetAwaiter().GetResult();

        Task UpdateSelectionAsync(Selection selection);

        void UpdateSelection(Selection selection);

        Task SelectSummonerSpellsAsync(Spell Left, Spell Right);

        void SelectSummonerSpells(Spell Left, Spell Right);
    }
}
