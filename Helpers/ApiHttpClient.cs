using LibraryMgmt.WebApp.MVC.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace LibraryMgmt.WebApp.MVC.Helper
{
    public class ApiHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _accessToken;

        public ApiHttpClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public string AccessToken => _accessToken;

        public async  Task<(TResponse Data, HttpStatusCode StatusCode)> GetAccessTokenAsync<TResponse,TRequest>(TRequest user)
        {
            try
            {
                string requestUrl = $"Auth/login";
                string serializedData = JsonConvert.SerializeObject(user);
                HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                request.Content = content;
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadAsAsync<TResponse>();

                    //_httpContextAccessor?.HttpContext?.Response.Cookies.Append("jwtToken", _accessToken);
                    return (loginResponse, response.StatusCode);
                }
                else
                {
                    return (default(TResponse), response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle request exception
                throw new Exception("API request failed. Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An error occurred while processing the API request.", ex);
            }

        }
        public async Task<(TResponse Data, HttpStatusCode StatusCode)> GetAsync<TResponse>(string apiUrl)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                _accessToken = _httpContextAccessor.HttpContext.Request.Cookies["jwtToken"];
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                }
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    TResponse responseData = await response.Content.ReadAsAsync<TResponse>();
                    return (responseData, response.StatusCode);
                }
                else 
                {
                    return (default(TResponse), response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle request exception
                throw new Exception("API request failed. Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An error occurred while processing the API request.", ex);
            }
        }

        public async Task<(TResponse Data, HttpStatusCode StatusCode)> PostAsync<TRequest, TResponse>(string apiUrl, TRequest requestData)
        {
            try
            {
                string serializedData = JsonConvert.SerializeObject(requestData);
                HttpContent content = new StringContent(serializedData, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = content;
                _accessToken = _httpContextAccessor.HttpContext.Request.Cookies["jwtToken"];
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                }
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {

                    TResponse responseData = await response.Content.ReadAsAsync<TResponse>();
                    return (responseData, response.StatusCode);
                }
                else
                {
                    return (default(TResponse), response.StatusCode);
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle request exception
                throw new Exception("API request failed. Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An error occurred while processing the API request.", ex);
            }
        }

        public async Task<HttpStatusCode> DeleteAsync<TRequest>(string apiUrl, TRequest id)
        {
            try
            {
                string url = $"{apiUrl}{id}".Replace(" ", "%20");

                // Create a new HttpRequestMessage with DELETE method
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
                _accessToken = _httpContextAccessor.HttpContext.Request.Cookies["jwtToken"];
                // Set the access token in the request headers if provided
                if (!string.IsNullOrEmpty(_accessToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                }

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.StatusCode==HttpStatusCode.OK)
                {
                    
                    return response.StatusCode;
                }
                else
                {
                    // Handle error response
                    return response.StatusCode;
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle request exception
                throw new Exception("API request failed. Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An error occurred while processing the API request.", ex);
            }
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
