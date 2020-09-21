using Pyke.Lobby.Models.Party;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Lobby
{
    public class ClientLobby
    {
        private PykeAPI pykeAPI;

        public ClientLobby(PykeAPI pykeAPI)
        {
            this.pykeAPI = pykeAPI;
        }

        public async Task<List<CustomGame>> GetCustomGamesAsync() => await pykeAPI.RequestHandler.StandardGet<List<CustomGame>>("/lol-lobby/v1/custom-games");

        public List<CustomGame> GetCustomGames() => GetCustomGamesAsync().GetAwaiter().GetResult();

        public async Task<CustomGame> GetCustomGameByIdAsync(int id) => await pykeAPI.RequestHandler.StandardGet<CustomGame>($"/lol-lobby/v1/custom-games/{id}");

        public CustomGame GetCustomGameById(int id) => GetCustomGameByIdAsync(id).GetAwaiter().GetResult();

        public async Task<Party> GetCurrentPartyAsync() => await pykeAPI.RequestHandler.StandardGet<Party>("/lol-lobby/v2/lobby");

        public Party GetCurrentParty() => GetCurrentPartyAsync().GetAwaiter().GetResult();
    }
}
