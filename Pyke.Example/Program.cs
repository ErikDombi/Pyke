using Pyke;
using Pyke.ChampSelect.Models;
using Pyke.Events;
using Pyke.Events.Models;
using Pyke.Websocket;
using System;
using System.Linq;
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
            API = new PykeAPI(Serilog.Events.LogEventLevel.Verbose).ConnectAsync().GetAwaiter().GetResult();

            API.Events.SubscribeAllEvents();
            API.Events.GameflowStateChanged += Events_GameflowStateChanged;
            API.Events.OnMatchFound += Events_MatchFoundStatusChanged;
            API.Events.OnChampSelectTurnToPick += Events_OnChampSelectTurn;
            Console.ReadLine();
        }

        private static int index = 0;
        private static string[] champs = { "Annie", "Garen", "Camille", "Corki", "Trundle" };
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
                API.ChampSelect.SelectChampion("Draven", true);
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
