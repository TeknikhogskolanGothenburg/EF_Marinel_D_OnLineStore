using OnLineStore.Domain;
using OnLineStore.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnLineStoreUI
{
    class Program
    {
        private static StoreContext _context = new StoreContext();


        static void Main(string[] args)
        {

            //AddProduct();
            //AddProducts();
            //AddDiffrentObjects();
            //CustomerFilterByName();
            //CustomerFilterLike();
            //UpdateCustomerDisconnectedClient();
            //DeleteMany();
            //AllProducts();
            //CustomerWithPassword();

            


        }

       

        // Filter in 1 to 1 relationship
        private static void CustomerWithPassword()
        {
            var customerWithPassword = _context.Customers.Where(c => c.Login.Password.Contains("Pass1")).ToList();


            foreach (var customer in customerWithPassword)
            {
                Console.WriteLine(customer.FirstName);
            }
            Console.ReadLine();

        }

        // See all products
        private static void AllProducts()
        {

            var products = (from Product in _context.Products select Product).ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.ReadLine();
        }
    
        // Delete By Contains...
        private static void DeleteMany()
        {
            var products = _context.Products.Where(p => p.ProductName.Contains("6"));
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
        }


        // Update Disconnected Client
        private static void UpdateCustomerDisconnectedClient()
        {
            var customer = _context.Customers.FirstOrDefault();
            customer.LastName = "Hejhej";
            using (var newContextInstance = new StoreContext())
            {
                newContextInstance.Customers.Update(customer);
                newContextInstance.SaveChanges();
            }

        }


        // Filter LIKE - FirstName start with "P"
        private static void CustomerFilterLike()
        {
            var customersP = _context.Customers.Where(c => EF.Functions.Like(c.FirstName, "P%")).ToList();
            
        }

        // Where by name
        private static void CustomerFilterByName()
        {
            var name = "Marinel";
            var customer = _context.Customers.Where(c => c.FirstName == name);
          

        }

        //Adding Diffrent Objects
        private static void AddDiffrentObjects()
        {
            var p6 = new Product { ProductName = "iPhone 6", UnitPrice = 3399 };
            var c1 = new Customer { FirstName = "Marinel", LastName = "Dimitrije", Adress = "Gamla Göteborgsv. 18"};
           

            using (var context = new StoreContext())
            {
                context.AddRange(p6,c1 );
                context.SaveChanges();
            }
        }

        //Adding ONE product
        private static void AddProduct()
        {

            var p1 = new Product { ProductName = "iPhone 5", UnitPrice = 2399 };

            using (var context = new StoreContext())
            {
                context.Products.Add(p1);
                context.SaveChanges();
            }
        }

        //Adding MANY products
        private static void AddProducts()
        {


            var p2 = new Product { ProductName = "iPhone 6", UnitPrice = 3399 };
            var p3 = new Product { ProductName = "iPhone 6s", UnitPrice = 4399 };
            var p4 = new Product { ProductName = "iPhone 7", UnitPrice = 5399 };

            using (var context = new StoreContext())
            {
                context.Products.AddRange(p2, p3, p4);
                context.SaveChanges();
            }


        }


    }

}
