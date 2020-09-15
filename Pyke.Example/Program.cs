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
            API = new PykeAPI(Serilog.Events.LogEventLevel.Information).ConnectAsync().GetAwaiter().GetResult();

            API.Events.SubscribeAllEvents();
            API.Events.OnChampSelectTurnToPick += Events_OnChampSelectTurnToPick;

            while (true)
            {
                var url = Console.ReadLine();
            }
        }

        private static int index = 0;
        private static string[] champs = { "garen", "yasuo", "corki" };
        private static void Events_OnChampSelectTurnToPick(object sender, SessionActionType e)
        {
            if(e == SessionActionType.Ban)
            {
                API.ChampSelect.SelectChampion(champs[index], true);
                index++;
            }else
            {
                API.ChampSelect.SelectChampion("yone", true);
                API.ChampSelect.SelectSummonerSpells(Spell.Exhaust, Spell.Cleanse);
            }
        }
    }
}
