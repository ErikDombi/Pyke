using Pyke.Summoners.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Summoners
{
    public class Summoners
    {
        private PykeAPI leagueAPI;
        public Summoners(PykeAPI API)
        {
            leagueAPI = API;
        }

        public async Task<Summoner> GetSummonerByIdAsync(long id) => 
            await leagueAPI.RequestHandler.StandardGet<Summoner>($"/lol-summoner/v1/summoners/{id}");

        public Summoner GetSummonerById(long id) => GetSummonerByIdAsync(id).GetAwaiter().GetResult();

        public async Task<Summoner> GetSummonerByPuuidAsync(long Puuid) =>
            await leagueAPI.RequestHandler.StandardGet<Summoner>($"/lol-summoner/v2/summoners/puuid/{Puuid}");

        public Summoner GetSummonerByPuuid(long Puuid) => GetSummonerByPuuidAsync(Puuid).GetAwaiter().GetResult();

        public async Task<List<BasicSummoner>> GetSummonerNamesByIds(int[] ids) =>
            throw new NotImplementedException();
    }
}
