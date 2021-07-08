using System;
using System.Linq;
namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Config config = new Config();

            ApplicationContext context = new ApplicationContext(config);

            Category category = new Category("Phone");
            context.AddRange(new Category("Phone"), new Category("Notebook"));
            context.SaveChanges();

            var categories = context.Categories;


            Product product = new Product("iPhone X", 1500)
            {
                Category = (from c in context.Categories
                              where c.Name == "Phone"
                              select c).First()
            };

            Product product2 = new Product("Asus rog strix", 3500)
            {
                Category = (from c in context.Categories
                              where c.Name == "Notebook"
                              select c).First()
            };

            context.AddRange(product, product2);
            context.SaveChanges();


            Discount discount = new Discount() { Value = 5 };
            context.Add(discount);
            context.SaveChanges();

            User user = new User("Bob", "Crosby") {Age = 32 };
            context.Add(user);
            context.SaveChanges();


            UserAddress userAddress = new UserAddress("Kharkov", "Heroiv Pratsi", "380673564775")
            {
                User = (from c in context.Users
                        where c.FirstName == "Bob" && c.LastName == "Crosby"
                        select c).First()
            };
            context.Add(userAddress);
            context.SaveChanges();


            Cart cart = new Cart()
            {
                UserId =
                (from c in context.Users
                 where c.FirstName == "Bob" && c.LastName == "Crosby"
                 select c.Id).First(),

                Discount = (from d in context.Discounts
                           where d.Value == 5
                           select d).First()
            };
            context.Add(cart);
            context.SaveChanges();

            CartItem cartItem = new CartItem()
            {
                Product = (from p in context.Products
                           where p.Name == "iPhone X"
                           select p).First(),
                
                Cart = (from c in context.Carts
                        where c.User.FirstName == "Bob" && c.User.LastName == "Crosby"
                        select c).First(),
                Count = 1
            };

            context.Add(cartItem);
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
