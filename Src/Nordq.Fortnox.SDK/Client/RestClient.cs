using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nordq.Fortnox.SDK.Exceptions;

namespace Nordq.Fortnox.SDK.Client
{
    internal class RestClient
    {
        private readonly ApiHttpSettings _settings;
        private readonly string _clientSecret;
        private readonly string _accessToken;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        internal RestClient(ApiHttpSettings settings, string clientSecret, string accessToken)
        {
            _settings = settings;
            _clientSecret = clientSecret;
            _accessToken = accessToken;
            _jsonSerializerSettings = new JsonSerializerSettings {MaxDepth = 128};
        }

        internal async Task<T> GetAsync<T>(string path, int limit = 500, int? page = null)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{_settings.ApiBaseUrl}{path}?limit={limit}";
                if (page.HasValue)
                    uri += $"&page={page.Value}";

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Access-Token", _accessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", _clientSecret); 

                var restResponse = await client.GetAsync(uri);

                if (!restResponse.IsSuccessStatusCode)
                    throw new FortnoxHttpException($"[HttpGet] Call to '{uri}' was unsuccessful, details: '{restResponse.ReasonPhrase}'", typeof(T));

                var body = await restResponse.Content.ReadAsStringAsync();
                var deserializedResponse = JsonConvert.DeserializeObject<T>(body, _jsonSerializerSettings);
                return deserializedResponse;
            }
        }

        internal async Task<TR> Post<T, TR>(string path, T model)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{_settings.ApiBaseUrl}{path}";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Access-Token", _accessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", _clientSecret);

                var json = JsonConvert.SerializeObject(model, _jsonSerializerSettings);
                var restResponse = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, _settings.ContentType));

                if (!restResponse.IsSuccessStatusCode)
                    throw new FortnoxHttpException($"[HttpPost] Call to '{uri}' was unsuccessful, details: '{restResponse.ReasonPhrase}'", typeof(T));

                var body = await restResponse.Content.ReadAsStringAsync();
                var deserializedResponse = JsonConvert.DeserializeObject<TR>(body, _jsonSerializerSettings);
                return deserializedResponse;
            }
        }

        internal async Task<HttpResponseMessage> Post<T>(string path, T model)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{_settings.ApiBaseUrl}{path}";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Access-Token", _accessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", _clientSecret);

                var json = JsonConvert.SerializeObject(model, _jsonSerializerSettings);
                var restResponse = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, _settings.ContentType));

                if (!restResponse.IsSuccessStatusCode)
                    throw new FortnoxHttpException($"[HttpPost] Call to '{uri}' was unsuccessful, details: '{restResponse.ReasonPhrase}'", typeof(T));

                return restResponse;
            }
        }

        internal async Task<TR> Put<T, TR>(string path, T model)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{_settings.ApiBaseUrl}{path}";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Access-Token", _accessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", _clientSecret);

                var json = JsonConvert.SerializeObject(model);
                var restResponse = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, _settings.ContentType));

                if (!restResponse.IsSuccessStatusCode)
                    throw new FortnoxHttpException($"[HttpPost] Call to '{uri}' was unsuccessful, details: '{restResponse.ReasonPhrase}'", typeof(T));

                var body = await restResponse.Content.ReadAsStringAsync();
                var deserializedResponse = JsonConvert.DeserializeObject<TR>(body, _jsonSerializerSettings);
                return deserializedResponse;
            }
        }

        internal async Task<HttpResponseMessage> Put<T>(string path, T model)
        {
            using (var client = new HttpClient())
            {
                var uri = $"{_settings.ApiBaseUrl}{path}";
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Access-Token", _accessToken);
                client.DefaultRequestHeaders.Add("Client-Secret", _clientSecret);

                var json = JsonConvert.SerializeObject(model, _jsonSerializerSettings);
                var restResponse = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, _settings.ContentType));

                if (!restResponse.IsSuccessStatusCode)
                    throw new FortnoxHttpException($"[HttpPost] Call to '{uri}' was unsuccessful, details: '{restResponse.ReasonPhrase}'", typeof(T));

                return restResponse;
            }
        }
    }
}
