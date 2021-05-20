using NUnit.Framework;
using Pyke;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Pyke.Tests
{
    public class Tests
    {
        PykeAPI API;

        [Test, Order(1)]
        public void CheckConnection()
        {
            if (!Process.GetProcesses().Any(_ => _.MainWindowTitle == "League of Legends"))
                throw new Exception("League of Legends Client not Open");

            API = new PykeAPI(Serilog.Events.LogEventLevel.Information);

            AutoResetEvent wait = new AutoResetEvent(false);
            API.PykeReady += (o, e) => wait.Set(); // Need to wait for PykeReady to be fired before testing CheckDDragonData()
            API.ConnectAsync().ConfigureAwait(true);

            Assert.IsTrue(wait.WaitOne(TimeSpan.FromSeconds(20)));
        }

        [Test, Order(2)]
        public void CheckDDragonData()
        {
            Assert.NotNull(API.Champions);

            Assert.Pass();
        }

        [Test, Order(3)]
        public void CheckDDragonDataValid()
        {
            Assert.AreEqual(API.Champions.First().Name, "Aatrox");

            Assert.Pass();
        }
    }
}