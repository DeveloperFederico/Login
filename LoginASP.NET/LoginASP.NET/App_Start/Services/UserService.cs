using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using LoginASP.NET.Models;
using Newtonsoft.Json;
using System.Text;

namespace LoginASP.NET.App_Start.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenViewModel> LoginAsync(string username, string password)
        {
            var objeto = new
            {
                username = username,
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7253/api/User/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<TokenViewModel>(await response.Content.ReadAsStringAsync());
                return token;
            }
            else
            {
                // Manejar el error si la autenticación falla
                throw new Exception("Error de autenticación");
            }
        }
    }
}