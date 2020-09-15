using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.ChampSelect.Models
{
    public class PinDropSummoner
    {
        [JsonProperty("isLocalSummoner")]
        public bool IsLocalSummoner { get; set; }

        [JsonProperty("isPlaceholder")]
        public bool IsPlaceholder { get; set; }

        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("lanePosition")]
        public int LanePosition { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        // TODO: Verify this parses correctly accross all modes
        /// <summary>
        /// This may not work accross all modes and is untested
        /// </summary>
        [JsonProperty("position")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Lane PositionUnsafe { get; set; }

        [JsonProperty("slotId")]
        public int SlotId { get; set; }
    }

    public class PinDrop
    {
        [JsonProperty("mapSide")]
        public string MapSide { get; set; }

        [JsonProperty("pinDropSummoners")]
        public List<PinDropSummoner> PinDropSummoners { get; set; }
    }

    public enum Lane
    {
        Top,
        Jungle,
        Mid,
        Bot,
        Support
    }
}
