using System;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new ReqresClient();

            var users = client.GetAllUsersAsync().GetAwaiter().GetResult();

            var user = client.GetUserByIdAsync(5).GetAwaiter().GetResult();

            var resources = client.GetAllResourcesAsync().GetAwaiter().GetResult();

            var resource = client.GetResourceByIdAsync(5).GetAwaiter().GetResult();

            var employee = client.PostEmployeeAsync(new { Name = "morpheus", Job = "leader" }).GetAwaiter().GetResult();

            var updatedEmployee = client.PutEmployeeAsync(new { Name = "morpheus", Job = "zion resident" }, 2).GetAwaiter().GetResult();
            var pathedEmployee = client.PatchEmployeeAsync(new Employee { Name = "morpheus", Job = "zion resident" }, 2).GetAwaiter().GetResult();

            client.DeleteUserAsync(2).GetAwaiter().GetResult();

            var getAllUsersDelayed = client.GetAllUsersDelayedAsync(3).GetAwaiter().GetResult();
        }
    }
}
