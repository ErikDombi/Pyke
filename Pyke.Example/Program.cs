using Pyke;
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
        private static LeagueAPI API;
        static void Main(string[] args)
        {
            API = new LeagueAPI().ConnectAsync().GetAwaiter().GetResult();

            API.Events.SubscribeEvent(EventType.OnSessionUpdated);
            API.Events.SubscribeEvent(EventType.GameflowStateChanged);
            API.Events.GameflowStateChanged += Events_GameflowStateChanged;
            API.Events.OnSessionUpdated += Events_OnSessionUpdated;
            API.Events.MatchFoundStatusChanged += Events_MatchFoundStatusChanged;
            API.Events.OnChampSelectTurnToPick += Events_OnChampSelectTurn;
            Console.ReadLine();
        }

        private static void Events_OnChampSelectTurn(object sender, ChampSelect.Models.Session e)
        {
            Console.WriteLine("it is your turn to select a champion");
        }

        private static void Events_MatchFoundStatusChanged(object sender, ReadyState e)
        {
            API.MatchMaker.AcceptMatch();
        }

        private static void Events_OnSessionUpdated(object sender, ChampSelect.Models.Session e)
        {

        }

        private static void Events_GameflowStateChanged(object sender, State e)
        {
            // Auto Select Cleanse & Teleport
            if(e == State.ChampSelect)
                API.ChampSelect.SelectSummonerSpells(ChampSelect.Models.Spell.Cleanse, ChampSelect.Models.Spell.Teleport);


        }
    }
}
