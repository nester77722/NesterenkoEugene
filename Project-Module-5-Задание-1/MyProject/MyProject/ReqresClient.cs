using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyProject
{
    public class ReqresClient : IReqresClient
    {
        private readonly string _baseUrl = @"https://reqres.in/api/";

        public async Task<Employee> PutEmployeeAsync(object employee, int id)
        {
            var url = $"{_baseUrl}users/{id}";

            return await MakeRequestAsync<Employee>(url, HttpMethod.Put, employee);
        }

        public async Task<Employee> PostEmployeeAsync(object employee)
        {
            var url = $"{_baseUrl}users";

            return await MakeRequestAsync<Employee>(url, HttpMethod.Post, employee);
        }

        public async Task<ReqresPagedResult<Resource>> GetAllResourcesAsync()
        {
            var url = $"{_baseUrl}unknown";

            return await MakeRequestAsync<ReqresPagedResult<Resource>>(url, HttpMethod.Get);
        }

        public async Task<ReqresPagedResult<User>> GetAllUsersAsync(int? page = null)
        {
            var url = page.HasValue ? $"{_baseUrl}users?page={page}" : $"{_baseUrl}users";

            return await MakeRequestAsync<ReqresPagedResult<User>>(url, HttpMethod.Get);
        }

        public async Task<Resource> GetResourceByIdAsync(int id)
        {
            var url = $"{_baseUrl}unknown/{id}";

            return await MakeRequestAsync<Resource>(url, HttpMethod.Get);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var url = $"{_baseUrl}users/{id}";

            var dataResponse = await MakeRequestAsync<ReqresSingleResult<User>>(url, HttpMethod.Get);

            return dataResponse.Data;
        }

        public async Task<T> MakeRequestAsync<T>(string url, HttpMethod httpMethod, object? body = null)
        {
            using (var httpClient = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage();
                requestMessage.RequestUri = new Uri(url);
                if (body is not null)
                {
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                }

                requestMessage.Method = httpMethod;

                var result = await httpClient.SendAsync(requestMessage);

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exceptions.ReqresClientException(null, $"Content of response: {await result.Content.ReadAsStringAsync()}\nError is {result.StatusCode}\nCode is {(int)result.StatusCode}");
                }
            }
        }

        public async Task<Employee> PatchEmployeeAsync(Employee employee, int id)
        {
            var url = $"{_baseUrl}users/{id}";

            return await MakeRequestAsync<Employee>(url, HttpMethod.Patch, employee);
        }

        public async Task DeleteUserAsync(int id)
        {
            var url = $"{_baseUrl}users/{id}";

            var response = await MakeRequestAsync<string>(url, HttpMethod.Delete);
        }

        public async Task<RegisterResponse> RegisterUserAsync(User user)
        {
            var url = $"{_baseUrl}register";

            return await MakeRequestAsync<RegisterResponse>(url, HttpMethod.Post, user);
        }

        public async Task<RegisterResponse> LoginUserAsync(User user)
        {
            var url = $"{_baseUrl}login";

            return await MakeRequestAsync<RegisterResponse>(url, HttpMethod.Post, user);
        }

        public async Task<ReqresPagedResult<User>> GetAllUsersDelayedAsync(int delay)
        {
            var url = $"{_baseUrl}users?delay={delay}";

            return await MakeRequestAsync<ReqresPagedResult<User>>(url, HttpMethod.Get);
        }
    }
}
