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

            API.Events.SubscribeEvent(EventType.GameflowStateChanged);
            API.Events.GameflowStateChanged += Events_GameflowStateChanged;
            Console.ReadLine();
        }

        private static void Events_GameflowStateChanged(object sender, State e)
        {
            Console.WriteLine("State Changed: " + e.ToString());
        }
    }
}
