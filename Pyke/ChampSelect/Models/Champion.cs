using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.ChampSelect.Models
{
    public class SelectionStatus
    {
        public bool banIntented { get; set; }
        public bool banIntentedByMe { get; set; }
        public bool isBanned { get; set; }
        public bool pickIntented { get; set; }
        public bool pickIntentedByMe { get; set; }
        public string pickIntentedPosition { get; set; }
        public bool pickedByOtherOrBanned { get; set; }
        public bool selectedByMe { get; set; }
    }

    public class Champion
    {
        public bool disabled { get; set; }
        public bool freeToPlay { get; set; }
        public bool freeToPlayForQueue { get; set; }
        public bool freeToPlayReward { get; set; }
        public int id { get; set; }
        public bool masteryChestGranted { get; set; }
        public int masteryLevel { get; set; }
        public int masteryPoints { get; set; }
        public string name { get; set; }
        public bool owned { get; set; }
        public List<object> positionsFavorited { get; set; }
        public bool rented { get; set; }
        public List<string> roles { get; set; }
        public SelectionStatus selectionStatus { get; set; }
        public string squarePortraitPath { get; set; }
    }
}
