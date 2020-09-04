using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Matchmaking
{
    public class MatchMaker : IMatchMaker
    {
        private PykeAPI leagueAPI;

        public MatchMaker(PykeAPI leagueAPI)
        {
            this.leagueAPI = leagueAPI;
        }

        /// <inheritdoc />
        public async Task DeclineMatchAsync() => await leagueAPI.RequestHandler.GetJsonResponseAsync(httpMethod: HttpMethod.Post, "/lol-matchmaking/v1/ready-check/decline", null);
        
        /// <inheritdoc />
        public void DeclineMatch() => DeclineMatchAsync().GetAwaiter().GetResult();

        /// <inheritdoc />
        public async Task AcceptMatchAsync() => await leagueAPI.RequestHandler.GetJsonResponseAsync(httpMethod: HttpMethod.Post, "/lol-matchmaking/v1/ready-check/accept", null);

        /// <inheritdoc />
        public void AcceptMatch() => AcceptMatchAsync().GetAwaiter().GetResult();

        /// <inheritdoc />
        public async Task<ReadyCheck> GetReadyCheckAsync() => await leagueAPI.RequestHandler.StandardGet<ReadyCheck>("lol-matchmaking/v1/ready-check");

        /// <inheritdoc />
        public ReadyCheck GetReadyCheck() => GetReadyCheckAsync().GetAwaiter().GetResult();

        /// <inheritdoc />
        public async Task CancelQueueAsync() => await leagueAPI.RequestHandler.GetJsonResponseAsync(HttpMethod.Delete, "lol-matchmaking/v1/search", null);

        /// <inheritdoc />
        public void CancelQueue() => CancelQueueAsync().GetAwaiter().GetResult();

        /// <inheritdoc />
        public async Task<QueueInfo> GetQueueInfoAsync() => await leagueAPI.RequestHandler.StandardGet<QueueInfo>("lol-matchmaking/v1/search");

        /// <inheritdoc />
        public QueueInfo GetQueueInfo() => GetQueueInfoAsync().GetAwaiter().GetResult();
    }
}
