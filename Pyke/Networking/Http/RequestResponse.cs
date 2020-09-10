using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebSocketSharp.Net;

namespace Pyke.Networking.Http
{
    public class RequestResponse<TResponseType>
    {
        public HttpResponseMessage httpResponseMessage;
        public string Content;
        public TResponseType ParsedResponse;
        public bool didFail => httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK || httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NoContent;
        public RequestResponseError ResponseError;

        public RequestResponse(HttpResponseMessage httpResponseMessage, string Content, TResponseType ParsedObject) {
            this.httpResponseMessage = httpResponseMessage;
            this.Content = Content;
            this.ParsedResponse = ParsedObject;
            if (didFail)
                this.ResponseError = JsonConvert.DeserializeObject<RequestResponseError>(Content);
        }
    }

    public class RequestResponseError
    {
        [JsonProperty("errorCode")]
        public string errorCode;
        [JsonProperty("httpStatus")]
        public int statusCode;
        [JsonProperty("message")]
        public string errorMessage;
    }
}
