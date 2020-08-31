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
            API.Events.SubscribeAllEvents();
            API.Events.OnSessionUpdated += Events_OnSessionUpdated;
            API.Events.GameflowStateChanged += Events_GameflowStateChanged;
            Console.ReadLine();
        }

        private static void Events_GameflowStateChanged(object sender, State e)
        {
            Console.WriteLine(e.ToString());
        }

        private static void Events_OnSessionUpdated(object sender, ChampSelect.Models.Session e)
        {
            Console.Clear();
            Console.WriteLine(string.Join(", ", API.ChampSelect.GetFriendlyRoster()?.Select(t => t.ChampionName)));
            Console.WriteLine(string.Join(", ", API.ChampSelect.GetEnemyRoster()?.Select(t => t.ChampionName)));
        }
    }
}
