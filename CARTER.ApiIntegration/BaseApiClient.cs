using CARTER.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace CARTER.ApiIntegration
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettingModel _apiSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IOptions<ApiSettingModel> apiSettings)
        {
            _apiSettings = apiSettings.Value;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Environment: {environment}");
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                    typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        protected async Task<TResponse> PostByFormAsync<TResponse, T>(string url, T data)
        {
            try
            {
                var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiSettings.BaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var content = new MultipartFormDataContent();

                foreach (var prop in data.GetType().GetProperties())
                {
                    var value = prop.GetValue(data);
                    if (value is IFormFile)
                    {
                        var file = value as IFormFile;
                        content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                        content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = prop.Name, FileName = file.FileName };
                    }
                    else
                    {
                        content.Add(new StringContent(JsonConvert.SerializeObject(value)), prop.Name);
                    }
                }

                var response = await client.PostAsync(url, content);
                var body = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                        typeof(TResponse));

                    return myDeserializedObjList;
                }
                return JsonConvert.DeserializeObject<TResponse>(body);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected async Task<TResponse> PostByBodyAsync<TResponse, T>(string url, T data)
        {
            try
            {
                var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiSettings.BaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                JsonContent requestBody = JsonContent.Create(data);

                var response = await client.PostAsync(url, requestBody);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(responseBody,
                        typeof(TResponse));

                    return myDeserializedObjList;
                }
                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected async Task<TResponse> PutByBodyAsync<TResponse, T>(string url, T data)
        {
            try
            {
                var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiSettings.BaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                JsonContent requestBody = JsonContent.Create(data);

                var response = await client.PutAsync(url, requestBody);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(responseBody,
                        typeof(TResponse));

                    return myDeserializedObjList;
                }
                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
