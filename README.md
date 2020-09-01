![Pyke](Resources/Pyke.png)

[![Pyke](https://img.shields.io/github/workflow/status/wickedlizerd/Pyke/.NET%20Core?color=blue&label=Latest%20Build&logo=.NET&style=flat-square)](https://github.com/wickedlizerd/Pyke/actions?query=workflow%3A%22.NET+Core%22)[![Nuget](https://img.shields.io/nuget/v/pyke?color=blue&label=Nuget&logo=Nuget&logoColor=white&style=flat-square)](https://www.nuget.org/packages/Pyke/)[![Nuget Prerelease](https://img.shields.io/nuget/vpre/pyke?color=green&label=Nuget%20Pre-Release&logo=nuget&logoColor=white&style=flat-square)](https://www.nuget.org/packages/Pyke/)

A C# Library for interacting with the League of Legends Client LCU.


## Usage Example
This example shows how to hook GameglowState Changes, which we can use to detect if we are in matchmaking, champ select, post-game summary, etc...
```cs
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
 ```

## Features
 [X] = Completed
 [ ] = Planned

### Champ Select
 - [X] Get All Champions
 - [X] Get Pickable Champions
 - [X] Get Bannable Champions
 - [X] Get Current Champ Select Session
 - [X] Select & Lock in a Champion
 - [X] Set Champ Select Session Action
 - [X] Get Active Trades (And trade by id)
 - [X] Accept/Decline/Request/Cancel a trade
 - [X] Get Friendly, Enemey, and full team compositions 
 - [X] Get list of Pickable Skins (by id)
 - [X] Select Summoner Spells
 - [ ] Select Skin
 - [ ] Select Ward Skin
 - [ ] Ban Champion

### MatchMaking
 - [X] Accept/Decline Match
 - [X] Get Ready Check Info
 - [X] Cancel Queue
 - [ ] Select MatchMaking settings (gamemode, map, mode)
 - [ ] Create Lobby
 - [ ] Search For Match

### Client Info
 - [X] Get Client Version
 - [ ] Get IO / Running Process Info

### Events
 - [X] GameflowStateChanged (Fired when switching between Lobby, Matchmaking, Champ Select, In Game, PostGame Summary, "none")
 - [X] OnMatchFound 
 - [X] SelectedChampionChanged (Fired when you hover a new champion in champ select, or lock in a champion)
 - [X] ChampionTradeRecieved (Fired whenever ANY changes occur within the trading system. Including: a new trade available, a trade has been requested, a trade has been declined/accepted)
 - [X] OnChampSelectTurnToPick (Fired whenever it is your turn to pick or ban a champion. Event passes `PickType` which specifies if it is your turn to pick or ban)
 - [X] OnSessionUpdated (Fired whenever anything changes during champ select, including the timer. It is reccomended you don't put anything too resource intensive inside this event as it fires very often)
 - [ ] OnSummonerSelectedChampion (Event passes `SummonerSelection` which contains summoner info (such as their team, name, summoner spells), and selection info (Such as champion, pick or ban))
 - [ ] A bunch of Direct Message Events
 - [ ] Friend Request Events
 - [ ] On Login/Logout
 - [ ] Literally so many more

 ### Login/Account
  - [X] Get Session Info
  - [ ] Login/Logout
  - [ ] Get Current Summoner Info

## Libraries Used
 Pyke was made possible using the following libraries
  - LCU-Sharp
  - Json.NET

  
