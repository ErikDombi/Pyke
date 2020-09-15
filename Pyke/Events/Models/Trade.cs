using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Events.Models
{
    
    public class Trade
    {
        // /lol-champ-select/v1/session/trades/{id}

        public int cellId { get; set; }
        public int id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Tradestate state { get; set; }
    }

    public enum Tradestate
    {
        AVAILABLE,
        BUSY,
        INVALID,
        RECIEVED,
        SENT
    }
}
