using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pyke.Networking.Http
{
    /// <inheritdoc cref="ILeagueRequestHandler" />
    internal class LeagueRequestHandler : RequestHandler, ILeagueRequestHandler
    {
#pragma warning disable CS0169
        private PykeAPI leagueAPI;

        /// <inheritdoc />
        public int Port { get; set; }

        /// <inheritdoc />
        public string Token { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="LeagueRequestHandler"/> class.
        /// </summary>
        /// <param name="port">The league client's port.</param>
        /// <param name="token">The user's Basic authentication token.</param>
        public LeagueRequestHandler(int port, string token, PykeAPI api)
        {
            leagueAPI = api;
            ChangeSettings(port, token);
        }

        /// <inheritdoc />
        public void ChangeSettings(int port, string token)
        {
            Port = port;
            Token = token;
            CreateHttpClient();

            var authTokenBytes = Encoding.ASCII.GetBytes($"riot:{token}");
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authTokenBytes));
            HttpClient.BaseAddress = new Uri($"https://127.0.0.1:{port}/");
        }

        /// <inheritdoc />
        public async Task<string> GetJsonResponseAsync(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters = null)
        {
            return await GetJsonResponseAsync<object>(httpMethod, relativeUrl, queryParameters, null).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<string> GetJsonResponseAsync<TRequest>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters, TRequest body)
        {
            var request = await PrepareRequestAsync(httpMethod, relativeUrl, queryParameters, body).ConfigureAwait(false);
            var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
            //response.EnsureSuccessStatusCode();
            return GetResponseContentAsync(response).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public async Task<TResponse> GetResponseAsync<TResponse>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters = null)
        {
            return await GetResponseAsync<object, TResponse>(httpMethod, relativeUrl, queryParameters, null).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<TResponse> GetResponseAsync<TRequest, TResponse>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters, TRequest body)
        {
            var json = await GetJsonResponseAsync(httpMethod, relativeUrl, queryParameters, body).ConfigureAwait(false);
            return await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(json)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<RequestResponse<TResponse>> HttpRequest<TRequest, TResponse>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters, TRequest body)
        {
            leagueAPI.logger.Verbose(httpMethod.ToString().ToUpper() + " " + relativeUrl);
            var request = await PrepareRequestAsync(httpMethod, relativeUrl, queryParameters, body);
            var response = await HttpClient.SendAsync(request);
            var content = await GetResponseContentAsync(response);
            TResponse parsedObject = default(TResponse);
            try
            {
                parsedObject = JsonConvert.DeserializeObject<TResponse>(content);
            }
            catch (Exception ex)
            {
                leagueAPI.logger.Error("Exception parsing content in HttpRequest\n" + ex.ToString());
            }
            return new RequestResponse<TResponse>(response, content, parsedObject);
        }

        /// <inheritdoc />
        public async Task<RequestResponse<TResponse>> HttpRequest<TResponse>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters) => await HttpRequest<object, TResponse>(httpMethod, relativeUrl, queryParameters, null);

        public async Task<RequestResponse<object>> HttpRequest(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters) => await HttpRequest<object, object>(httpMethod, relativeUrl, queryParameters, null);
        
        public async Task<RequestResponse<object>> HttpRequest<TBody>(HttpMethod httpMethod, string relativeUrl, IEnumerable<string> queryParameters, TBody body) => await HttpRequest<object, object>(httpMethod, relativeUrl, queryParameters, body);
        
        public async Task<TResponse> StandardPost<TRequest, TResponse>(string url, TRequest body)
        {
            var response = await HttpRequest<TRequest, TResponse>(HttpMethod.Post, url, null, body);
            if (response.didFail) return default(TResponse);
            return response.ParsedResponse;
        }

        public async Task StandardPost<TRequest>(string url, TRequest body) => await StandardPost<TRequest, object>(url, body);

        public async Task<TResponse> StandardPost<TResponse>(string url) => await StandardPost<object, TResponse>(url, null);

        public async Task StandardPost(string url) => await GetJsonResponseAsync(HttpMethod.Post, url, null);

        public async Task<TResponse> StandardGet<TRequest, TResponse>(string url, TRequest body)
        {
            var response = await HttpRequest<TRequest, TResponse>(HttpMethod.Get, url, null, body);
            if (response.didFail) return default(TResponse);
            return response.ParsedResponse;
        }

        public async Task StandardGet<TRequest>(string url, TRequest body) => await StandardGet<TRequest, object>(url, body);

        public async Task<TResponse> StandardGet<TResponse>(string url) => await StandardGet<object, TResponse>(url, null);
    }
}
