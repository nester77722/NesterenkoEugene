using System;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new ReqresClient();

            var pagedUsers = client.GetAllUsersAsync(2).GetAwaiter().GetResult();
            var users = pagedUsers.Data;

            foreach(var u in users)
            {
                Console.WriteLine(u.FirstName);
                Console.WriteLine(u.LastName);
                Console.WriteLine(u.Id);
                Console.WriteLine();
            }

            var user = client.GetUserByIdAsync(2).GetAwaiter().GetResult();
            Console.WriteLine(user.Id);
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);

            Console.WriteLine(client.DeleteUserByIdAsync(2).GetAwaiter().GetResult());
            Console.WriteLine(client.CreateUserAsync(new User { FirstName = "Nick", Job = "Avenger" }).GetAwaiter().GetResult());

            var pagedResources = client.GetAllResourcesAsync(2).GetAwaiter().GetResult();
            var resources = pagedResources.Data;

            foreach (var r in resources)
            {
                Console.WriteLine(r.Name);
                Console.WriteLine(r.PantoneValue);
                Console.WriteLine(r.Year);
                Console.WriteLine();
            }

            var resource = client.GetResourceByIdAsync(2).GetAwaiter().GetResult();
            Console.WriteLine(resource.Id);
            Console.WriteLine(resource.Name);
            Console.WriteLine(resource.Year);

            var newUser = new User() { Id = 2, LastName = "Ivanov", FirstName = "Ivan", Job = "Helper" };
            var updateResult = client.UpdateUser(newUser).GetAwaiter().GetResult();
            Console.WriteLine(updateResult.Job);

            client.RegisterAsync("eve.holt@reqres.in", "pistol").GetAwaiter().GetResult();
            client.LoginAsync("eve.holt@reqres.in", "cityslicka").GetAwaiter().GetResult();
        }
    }
}
