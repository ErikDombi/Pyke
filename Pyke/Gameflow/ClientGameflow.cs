using Pyke.Gameflow.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Gameflow
{
    public class ClientGameflow
    {
        private PykeAPI pykeAPI;

        public ClientGameflow(PykeAPI pykeAPI)
        {
            this.pykeAPI = pykeAPI;
        }

        public async Task<bool> isSpectatingAsync() => await pykeAPI.RequestHandler.StandardGet<bool>("/lol-gameflow/v1/spectate");

        public bool isSpectating() => isSpectatingAsync().GetAwaiter().GetResult();

        public async Task<PlayerStatus> getPlayerStatusAsync() => await pykeAPI.RequestHandler.StandardGet<PlayerStatus>("/lol-gameflow/v1/gameflow-metadata/player-status");

        public PlayerStatus getPlayerStatus() => getPlayerStatusAsync().GetAwaiter().GetResult();

        public async Task QuitGameAsync() => await pykeAPI.RequestHandler.StandardPost("/lol-gameflow/v1/early-exit");

        public void QuitGame() => QuitGameAsync().GetAwaiter().GetResult();

        public async Task SpectateGameAsync(string SummonerName) => await pykeAPI.RequestHandler.StandardPost("/lol-gameflow/v1/spectate/launch", SummonerName);

        // Doesn't actually close the spectating window. This is a weird one. Come back to it.
        // TODO: Add CloseGame option that kills the league game task
        public async Task QuitSpectatingAsync() => await pykeAPI.RequestHandler.StandardPost("/lol-gameflow/v1/spectate/quit");
    }
}
