using Pyke.Networking.Http;
using Pyke.Networking.Http.Endpoints;
using Pyke.Websocket;
using System;
using System.Threading.Tasks;

namespace Pyke
{
    /// <summary>
    /// Represents an interface that can directly communicate to the league client's API.
    /// </summary>
    public interface ILeagueClientApi
    {
        /// <summary>
        /// Triggered when the client disconnects from the api.
        /// </summary>
        event EventHandler Disconnected;

        /// <summary>
        /// The request handler.
        /// </summary>
        ILeagueRequestHandler RequestHandler { get; }

        /// <summary>
        /// The event handler.
        /// </summary>
        ILeagueEventHandler EventHandler { get; }

        /// <summary>
        /// The riot client endpoint.
        /// </summary>
        IRiotClientEndpoint RiotClientEndpoint { get; }

        /// <summary>
        /// The process control endpoint.
        /// </summary>
        IProcessControlEndpoint ProcessControlEndpoint { get; }

        /// <summary>
        /// Reconnects to the league client api.
        /// </summary>
        Task ReconnectAsync();

        /// <summary>
        /// Disconnect from the league client api.
        /// </summary>
        void Disconnect();
    }
}
