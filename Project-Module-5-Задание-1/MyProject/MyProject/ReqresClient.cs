using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class ReqresClient : IReqresClient
    {
        private const string _baseUrl = "https://reqres.in/api/";
        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}users";

                var response = await httpClient.PostAsJsonAsync(url, user);

                response.EnsureSuccessStatusCode();

                return (int)response.StatusCode == 201;
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка при попытке создать пользователя!");
            }
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}users/{id}";

                var response = await httpClient.DeleteAsync(url);

                response.EnsureSuccessStatusCode();

                return (int)response.StatusCode == 204;
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка при попытке удалить пользователя!");
            }
        }

        public async Task<ReqresPagedResult<Resource>> GetAllResourcesAsync(int? page = null)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = page.HasValue ? $"{_baseUrl}unknown?page={page}" : $"{_baseUrl}unknown";

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ReqresPagedResult<Resource>>(payload);
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка в получении данных о пользователях!");
            }
        }

        public async Task<ReqresPagedResult<User>> GetAllUsersAsync(int? page = null)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = page.HasValue ? $"{_baseUrl}users?page={page}" : $"{_baseUrl}users";

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ReqresPagedResult<User>>(payload);
            }
            catch(Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка в получении данных о пользователях!");
            }
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}unknown/{id}";

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ReqresSingleResult<Resource>>(payload);

                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка получения данных о пользователе!");
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}users/{id}";

                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ReqresSingleResult<User>>(payload);

                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Ошибка получения данных о пользователе!");
            }
        }

        public async Task LoginAsync(string email, string password)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}login";

                var newUser = new
                {
                    email = email,
                    password = password
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Не удалось войти в аккаунт!");
            }
        }

        public async Task RegisterAsync(string email, string password)
        {
            try
            {
                using var httpClient = new HttpClient();

                var url = $"{_baseUrl}register";

                var newUser = new
                {
                    email = email,
                    password = password
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, httpContent);

                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Не удалось зарегистрировать пользователя!");
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                using var client = new HttpClient();

                var url = $"{_baseUrl}users/{user.Id}";

                var response = await client.PutAsJsonAsync(url, user);
                response.EnsureSuccessStatusCode();

                var payload = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<User>(payload);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exceptions.ReqresClientException(ex, "Не удалось обновить данные о пользователе!");
            }


        }
    }
}
