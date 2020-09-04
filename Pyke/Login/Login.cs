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
        private PykeAPI leagueAPI;

        public Login(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
        }

        public async Task<Pyke.Login.Models.Session> GetSessionAsync() => await leagueAPI.RequestHandler.StandardGet<Pyke.Login.Models.Session>("/lol-login/v1/session");

        public Pyke.Login.Models.Session GetSession() => GetSessionAsync().GetAwaiter().GetResult();
    }
}
