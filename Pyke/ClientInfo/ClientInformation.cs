using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.ClientInfo
{
    public class ClientInformation
    {
        private PykeAPI leagueAPI;

        public ClientInformation(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
        }

        public async Task<string> GetGameVersionAsync() => await leagueAPI.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, "/lol-patch/v1/game-version", null);
        public string GetGameVersion() => GetGameVersionAsync().GetAwaiter().GetResult();
    
    }
}
