using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Matchmaking
{
    public interface IMatchMaker
    {
        /// <summary>
        /// Decline a match. Only works if your are match making and a match is found.
        /// </summary>
        public Task DeclineMatchAsync();

        /// <summary>
        /// Decline a match. Only works if your are match making and a match is found.
        /// </summary>
        public void DeclineMatch();

        /// <summary>
        /// Accept a match. Only works if your are match making and a match is found.
        /// </summary>
        public Task AcceptMatchAsync();

        /// <summary>
        /// Accept a match. Only works if your are match making and a match is found.
        /// </summary>
        public void AcceptMatch();

        public Task<ReadyCheck> GetReadyCheckAsync();

        public ReadyCheck GetReadyCheck();

        public Task CancelQueueAsync();

        public void CancelQueue();

        /// <summary>
        /// Get general information about the current queue. Only works if user is already searching for a match.
        /// </summary>
        /// <returns></returns>
        public Task<QueueInfo> GetQueueInfoAsync();

        public QueueInfo GetQueueInfo();
    }
}
