using Pyke.ChampSelect;
using Pyke.ChampSelect.Models;
using Pyke.ClientInfo;
using Pyke.Events;
using Pyke.Login.Models;
using Pyke.Matchmaking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Pyke.Networking.Http;
using Pyke.Utility;
using Pyke.Websocket;
using Pyke.Networking.Http.Endpoints;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Core;

namespace Pyke
{
    public class PykeAPI : ILeagueClientApi
    {
        private readonly LeagueProcessHandler _processHandler;
        private readonly LockFileHandler _lockFileHandler;
        public event EventHandler Disconnected;
        public Networking.Http.ILeagueRequestHandler RequestHandler { get; }
        public Websocket.ILeagueEventHandler EventHandler { get; }
        public Networking.Http.Endpoints.IRiotClientEndpoint RiotClientEndpoint { get; }
        public Networking.Http.Endpoints.IProcessControlEndpoint ProcessControlEndpoint { get; }

        public IChampSelect ChampSelect { get; }
        public ILeagueEvents Events { get; }
        public IMatchMaker MatchMaker { get; }
        public ClientInformation ClientInfo { get; }
        public Login.Login Login { get; }
        public List<Champ> Champions { get; }

        public Summoners.Summoners Summoners { get; }

        public Logger logger;

        public PykeAPI(Serilog.Events.LogEventLevel DebugLevel = Serilog.Events.LogEventLevel.Information)
        {
            logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Is(DebugLevel)
            .CreateLogger();

            _processHandler = new LeagueProcessHandler();
            _lockFileHandler = new LockFileHandler();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueAPI"/> class.
        /// </summary>
        /// <param name="port">The league client API's port.</param>
        /// <param name="token">The authentication token.</param>
        /// <param name="eventHandler">The event handler.</param>
        private PykeAPI(int port, string token, Websocket.ILeagueEventHandler eventHandler, LeagueProcessHandler _pHandler, LockFileHandler _lfHandler, Logger logger)
        {
            this.logger = logger;
            _processHandler = _pHandler;
            _lockFileHandler = _lfHandler;
            EventHandler = eventHandler;
            RequestHandler = new LeagueRequestHandler(port, token, this);
            RiotClientEndpoint = new RiotClientEndpoint(RequestHandler);
            ProcessControlEndpoint = new ProcessControlEndpoint(RequestHandler);
            _processHandler.Exited += OnDisconnected;

            _processHandler = new LeagueProcessHandler();
            _lockFileHandler = new LockFileHandler();
            ChampSelect = new ChampSelect.ChampSelect(this);
            Events = new LeagueEvents(this);
            MatchMaker = new MatchMaker(this);
            ClientInfo = new ClientInformation(this);
            Login = new Login.Login(this);
            Summoners = new Summoners.Summoners(this);
            Champions = JsonConvert.DeserializeObject<ChampionInfo>(new WebClient().DownloadString("https://ddragon.leagueoflegends.com/cdn/10.16.1/data/en_US/champion.json"), Converter.Settings).Data.Values.ToList();
            logger.Information("Pyke Ready");
        }


        /// <summary>
        /// Connects to the league client api.
        /// </summary>
        /// <returns>A new instance of <see cref="LeagueAPI" /> that's connected to the client api.</returns>
        public async Task<PykeAPI> ConnectAsync()
        {
            var (port, token) = await GetAuthCredentialsAsync().ConfigureAwait(false);
            var eventHandler = new LeagueEventHandler(port, token);
            var api = new PykeAPI(port, token, eventHandler, _processHandler, _lockFileHandler, logger);
            return await EnsureConnectionAsync(api).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task ReconnectAsync()
        {
            var (port, token) = await GetAuthCredentialsAsync().ConfigureAwait(false);
            await Task.Run(() =>
            {
                RequestHandler.ChangeSettings(port, token);
                EventHandler.ChangeSettings(port, token);
            }).ConfigureAwait(false);
            await EnsureConnectionAsync(this).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public void Disconnect()
        {
            OnDisconnected(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the league client api authentication credentials.
        /// </summary>
        /// <returns>The port and auth token.</returns>
        private async Task<(int port, string token)> GetAuthCredentialsAsync()
        {
            await Task.Run(() => _processHandler.WaitForProcess()).ConfigureAwait(false);
            return await _lockFileHandler.ParseLockFileAsync(_processHandler.ExecutablePath).ConfigureAwait(false);
        }

        /// <summary>
        /// Ensures the connection is successful by sending a test request.
        /// </summary>
        /// <param name="api">The league client api.</param>
        /// <returns>The league client api.</returns>
        private async Task<PykeAPI> EnsureConnectionAsync(PykeAPI api)
        {
            while (true)
            {
                try
                {
                    await api.RequestHandler.GetResponseAsync<string>(HttpMethod.Get, "/riotclient/app-name").ConfigureAwait(false);
                    await Task.Run(() => api.EventHandler.Connect()).ConfigureAwait(false);
                    return api;
                }
                catch (Exception ex)
                {
                    logger.Error("Failed to connect to the League Client\n" + ex.Message);
                    await Task.Delay(100).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Invoked when the client is disconnected from the api.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnDisconnected(object sender, EventArgs e)
        {
            await Task.Run(() => EventHandler.Disconnect()).ConfigureAwait(false);
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
    }
}
