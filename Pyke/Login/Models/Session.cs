using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyke.Login.Models
{
    public class Session
    {
        [JsonProperty("accountId")]
        public int AccountId;

        [JsonProperty("connected")]
        public bool Connected;

        [JsonProperty("error")]
        public object Error;

        [JsonProperty("gasToken")]
        public object GasToken;

        [JsonProperty("idToken")]
        public string IdToken;

        [JsonProperty("isInLoginQueue")]
        public bool IsInLoginQueue;

        [JsonProperty("isNewPlayer")]
        public bool IsNewPlayer;

        [JsonProperty("puuid")]
        public string Puuid;

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SessionState State;

        [JsonProperty("summonerId")]
        public int SummonerId;

        [JsonProperty("userAuthToken")]
        public string UserAuthToken;

        [JsonProperty("username")]
        public string Username;
    }

    public enum SessionState
    {
        IN_PROGRESS,
        SUCCEEDED,
        LOGGING_OUT,
        ERROR
    }
}
