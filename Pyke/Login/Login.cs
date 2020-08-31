using Pyke.ChampSelect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Login
{
    public class Login
    {
        private LeagueAPI leagueAPI;

        public Login(LeagueAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
        }
         
        public async Task<Pyke.Login.Models.Session> GetSessionAsync() => JsonConvert.DeserializeObject<Pyke.Login.Models.Session>(
                await leagueAPI.RequestHandler.GetJsonResponseAsync(
                    httpMethod: HttpMethod.Get,
                    relativeUrl: "/lol-login/v1/session"
                )
            );

        public Pyke.Login.Models.Session GetSession() => GetSessionAsync().GetAwaiter().GetResult();
    }
}
