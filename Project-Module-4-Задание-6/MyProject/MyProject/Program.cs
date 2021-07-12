using System;
using System.Linq;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            var products = from p in context.Products
                           select new
                           {
                               ProductName = p.Name,
                               CategoryName = p.Category.Name,
                               Price = p.Price
                           };
            products = from p in products
                       orderby p.ProductName, p.Price
                       select p;

            Console.WriteLine("Products");
            foreach (var p in products)
            {
                Console.WriteLine(p.ProductName);
                Console.WriteLine(p.CategoryName);
                Console.WriteLine(p.Price);
                Console.WriteLine();
            }

            var categories = from c in context.Categories
                             select new
                             {
                                 Name = c.Name,
                                 TotalPrice = (from p in context.Products
                                               where p.CategoryId == c.Id
                                               select p.Price).Sum()
                             };

            Console.WriteLine("Categories");
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
                Console.WriteLine(c.TotalPrice);
                Console.WriteLine();
            }

            var userOrders = from u in context.Users
                             from o in context.Orders
                             where u.Id == o.UserId
                             select new
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 OrderId = o.Id,
                                 TotalPrice = o.Total,
                                 TotalDiscount = o.Total / 100 * o.Discount.Value
                             };

            Console.WriteLine("User Orders");
            foreach (var uO in userOrders)
            {
                Console.WriteLine(uO.FirstName);
                Console.WriteLine(uO.LastName);
                Console.WriteLine(uO.OrderId);
                Console.WriteLine(uO.TotalPrice);
                Console.WriteLine(uO.TotalDiscount);
                Console.WriteLine();
            }

            var ordersInfo = from p in context.Products
                             select new
                             {
                                 Name = p.Name,
                                 CategoryName = p.Category.Name,
                                 SoldCount = (from o in context.OrderItems
                                              where o.ProductId == p.Id
                                              select o.Count).Sum()
                             };

            Console.WriteLine("Orders Info");
            foreach (var oI in ordersInfo)
            {
                Console.WriteLine(oI.Name);
                Console.WriteLine(oI.CategoryName);
                Console.WriteLine(oI.SoldCount);
                Console.WriteLine();
            }

            var cartsInfo = from p in context.Products
                             select new
                             {
                                 Name = p.Name,
                                 CategoryName = p.Category.Name,
                                 CartCount = (from c in context.CartItems
                                              where c.ProductId == p.Id
                                              select c.Count).Sum()
                             };

            Console.WriteLine("Carts Info");
            foreach (var cI in cartsInfo)
            {
                Console.WriteLine(cI.Name);
                Console.WriteLine(cI.CategoryName);
                Console.WriteLine(cI.CartCount);
                Console.WriteLine();
            }

            var result = from cI in cartsInfo
                         join oI in ordersInfo on cI.Name equals oI.Name
                         select new
                         {
                             ProductName = cI.Name,
                             CategoryName = cI.CategoryName,
                             TotalCount = cI.CartCount + oI.SoldCount
                         };

            Console.WriteLine("Total Info");
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.CategoryName);
                Console.WriteLine(item.TotalCount);
                Console.WriteLine();
            }
        }
    }
}
