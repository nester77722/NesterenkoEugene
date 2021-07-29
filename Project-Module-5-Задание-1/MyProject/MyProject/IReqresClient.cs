using System.Net.Http;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IReqresClient
    {
        public Task DeleteUserAsync(int id);
        public Task<ReqresPagedResult<User>> GetAllUsersAsync(int? page);
        public Task<ReqresPagedResult<User>> GetAllUsersDelayedAsync(int delay);
        public Task<ReqresPagedResult<Resource>> GetAllResourcesAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<Resource> GetResourceByIdAsync(int id);
        public Task<RegisterResponse> LoginUserAsync(User user);
        public Task<Employee> PostEmployeeAsync(object employee);
        public Task<Employee> PutEmployeeAsync(object employee, int id);
        public Task<Employee> PatchEmployeeAsync(Employee employee, int id);
        public Task<RegisterResponse> RegisterUserAsync(User user);
        public Task<T> MakeRequestAsync<T>(string url, HttpMethod httpMethod, object body);
    }
}
