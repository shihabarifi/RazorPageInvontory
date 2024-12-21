using System.Text.Json;
using System.Text;
using RazorPageInvontory.Modules.UsersSys.Models;
using System.Net.Http;

namespace RazorPageInvontory.Modules.UsersSys.ADL
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "/api/user";
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateUserAsync(UserLoginRequest user)
        {
            var json = JsonSerializer.Serialize(user);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/login", content);
            return response.IsSuccessStatusCode;
        }
    }
        
    }
