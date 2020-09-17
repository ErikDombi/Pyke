using Pyke.Events;
using Pyke.Events.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyke.Example.GUI
{
    public partial class Form1 : Form
    {
        PykeAPI Pyke;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pyke = new PykeAPI().ConnectAsync().GetAwaiter().GetResult();
            Pyke.Events.SubscribeAllEvents();
            Pyke.Events.OnChampSelectTurnToPick += Events_OnChampSelectTurnToPick;
            Pyke.Events.GameflowStateChanged += Events_GameflowStateChanged;
            Pyke.Events.OtherSummonerSelectionUpdated += Events_OtherSummonerSelectionUpdated;
            Pyke.Events.SelectedChampionChanged += Events_SelectedChampionChanged;
            Pyke.Events.OnReadyStateChanged += Events_OnReadyStateChanged;
        }

        private void Events_OnReadyStateChanged(object sender, Events.Models.ReadyState e)
        {
            ReadyCheckGroup.Visible = true;
            ReadyCheckGroup.Text = $"Ready Check ({e.Timer.ToString()})";
            if(e.state != ReadyStateState.InProgress)
            {
                ReadyCheckGroup.Visible = false;
            }
        }

        private void Events_SelectedChampionChanged(object sender, Champ e)
        {
            this.Text = "Selected Champion: " + e.Name;
        }

        private void Events_OtherSummonerSelectionUpdated(object sender, Events.Models.SummonerSelection e)
        {
            try
            {
                if (e.SummonerInfo.SummonerId == Pyke.Login.GetSession().AccountId)
                {
                    if (e.SelectionInfo.Completed)
                    {
                        ChampSelectGroup.Visible = false;
                    }
                }
                var session = Pyke.ChampSelect.GetSession();
                myTeam = session.MyTeam.Where(t => t.ChampionId != 0).Select(t => Pyke.Champions.FirstOrDefault(c => c.Key == t.ChampionId).Name).ToArray();
                theirTeam = session.MyTeam.Where(t => t.ChampionId != 0).Select(t => Pyke.Champions.FirstOrDefault(c => c.Key == t.ChampionId).Name).ToArray();
                YourTeamList.Items.Clear();
                TheirTeamList.Items.Clear();
                YourTeamList.Items.AddRange(myTeam);
                TheirTeamList.Items.AddRange(theirTeam);
            }
            catch
            {

            }
        }

        string[] myTeam;
        string[] theirTeam;
        private void Events_GameflowStateChanged(object sender, Events.State e)
        {
            if(e == State.ChampSelect)
            {
                var session = Pyke.ChampSelect.GetSession();
                YourTeamList.Items.Clear();
                TheirTeamList.Items.Clear();
                myTeam = session.MyTeam.Where(t => t.ChampionId != 0).Select(t => Pyke.Champions.FirstOrDefault(c => c.Key == t.ChampionId).Name).ToArray();
                theirTeam = session.MyTeam.Where(t => t.ChampionId != 0).Select(t => Pyke.Champions.FirstOrDefault(c => c.Key == t.ChampionId).Name).ToArray();
            }
        }

        private void Events_OnChampSelectTurnToPick(object sender, ChampSelect.Models.SessionActionType e)
        {
            ChampSelectGroup.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pyke.ChampSelect.SelectChampion(textBox1.Text, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pyke.ChampSelect.SelectChampion(textBox1.Text, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pyke.MatchMaker.AcceptMatch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pyke.MatchMaker.DeclineMatch();
        }
    }
}
