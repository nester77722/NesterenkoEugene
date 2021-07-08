using System;
using System.Linq;
namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            Order order = new Order() { Discount = context.Discounts.First(), User = context.Users.First() };

            context.Add(order);
            context.SaveChanges();

            context.Add(new OrderItem() { Order = order, Product = context.Products.First(), Count = 1 });
            context.SaveChanges();

            var userInfo = from u in context.Users
                           from add in context.Addresses
                           from item in context.CartItems
                           where u.Id == add.UserId
                           where u.Id == item.Cart.UserId
                           select new
                           {
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               City = add.City,
                               Address = add.Address,
                               Product = item.Product,
                               TotalPrice = item.Product.Price * item.Count - (item.Product.Price * item.Count / 100 * 5)
                           };

            foreach (var u in userInfo)
            {
                Console.WriteLine(u.FirstName);
                Console.WriteLine(u.LastName);
                Console.WriteLine(u.City);
                Console.WriteLine(u.Address);
                Console.WriteLine(u.Product.Name);
                Console.WriteLine(u.TotalPrice);
            }
        }
    }
}
