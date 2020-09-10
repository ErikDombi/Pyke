using Pyke;
using Pyke.ChampSelect.Models;
using Pyke.Events;
using Pyke.Events.Models;
using Pyke.Websocket;
using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Pyke.Events.ILeagueEvents;

namespace Pyke.Example
{
    class Program
    {
        private static PykeAPI API;
        static void Main(string[] args)
        {
            API = new PykeAPI(Serilog.Events.LogEventLevel.Debug).ConnectAsync().GetAwaiter().GetResult();

            API.Events.SubscribeAllEvents();
            API.Events.OnReadyStateChanged += Events_OnReadyStateChanged;

            while (true)
            {
                var url = Console.ReadLine();
                var response = API.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, url, null);
            }
        }

        private static void Events_OnReadyStateChanged(object sender, ReadyState e)
        {
            if(e.state == ReadyStateState.InProgress && e.PlayerResponse == ReadyStatePlayerResponse.None)
            {
                API.MatchMaker.AcceptMatch();
            }
        }

        private static void Events_OtherSummonerSelectionUpdated(object sender, SummonerSelection e)
        {
            if (e.SelectionInfo.IsAllyAction)
            {
                if(e.SelectionInfo.Type == "pick")
                {
                    var summoner = API.Summoners.GetSummonerById(e.SummonerInfo.SummonerId);
                    Console.WriteLine("### " + summoner.DisplayName + (e.SelectionInfo.Completed ? " Locked in " : " Selected ") + API.Champions.FirstOrDefault(x => x.Key == e.SelectionInfo.ChampionId).Name);
                }
                else
                {
                    var summoner = API.Summoners.GetSummonerById(e.SummonerInfo.SummonerId);
                    Console.WriteLine("### " + summoner.DisplayName + (e.SelectionInfo.Completed ? " Locked in ban " : " Selected ban ") + API.Champions.FirstOrDefault(x => x.Key == e.SelectionInfo.ChampionId).Name);
                }
            }
        }

        private static int index = 0;
        private static string[] champs = { "Veigar" };
        private static void Events_OnChampSelectTurn(object sender, PickType e)
        {
            if (index >= champs.Length) index = 0;
            if (e == PickType.Ban)
            {
                API.ChampSelect.SelectChampion(champs[index], true);
                index++;
            }
            else
            {
                API.ChampSelect.SelectChampion("Fizz", true);
            }
        }

        private static void Events_MatchFoundStatusChanged(object sender, ReadyState e)
        {

        }

        private static void Events_GameflowStateChanged(object sender, State e)
        {
            
        }
    }
}
