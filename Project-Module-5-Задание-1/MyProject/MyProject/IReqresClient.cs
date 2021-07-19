using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IReqresClient
    {
        Task<ReqresPagedResult<User>> GetAllUsersAsync(int? page = null);
        Task<User> GetUserByIdAsync(int id);
        Task<Resource> GetResourceByIdAsync(int id);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUserByIdAsync(int id);
        Task<bool> CreateUserAsync(User user);
        Task<ReqresPagedResult<Resource>> GetAllResourcesAsync(int? page = null);
        Task RegisterAsync(string email, string password);
        Task LoginAsync(string email, string password);
    }
}
