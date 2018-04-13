using Microsoft.EntityFrameworkCore;
using OnLineStore.Data;
using OnLineStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynkOnLineStoreUI
{
    class Program
    {

        private static StoreContext ctx = new StoreContext();



        static void Main(string[] args)
        {
            Console.WriteLine("AddManyProducts() are starting now, first method");
            AddManyProducts();
            Console.WriteLine("LongTask() are starting now, second method");
            LongTask();
            Thread.Sleep(10000);// ConsoleUI go to sleep in 6000ms

            // ConsoleUI Sleep 10000 + LongTask sleep 8000 = 18000ms
            // 18000 - 12000 Addproducts sleep = 6000ms

        }



        //Jag valde att köra async och await på metoden nedan(AddManyProducts) pga att den kommer att längre tid än 
        //de andra metoder som jag kör igång i main programmet. Man slipper vänta på metoden tills den är klar 
        //man kan köra parallelt/samtidigt andra metoder. Man sparar tid.

        public static async void AddManyProducts()
        {
           

           await Task.Run(new Action(AddProducts));
           Console.WriteLine("AddManyProducts are finished now, first method");
            
           
        }


        private static void AddProducts()
        {

            var p2 = new Product { ProductName = "iPhone 6", UnitPrice = 3399 };
            var p3 = new Product { ProductName = "iPhone 6s", UnitPrice = 4399 };
            var p4 = new Product { ProductName = "iPhone 7", UnitPrice = 5399 };
            var p5 = new Product { ProductName = "iPhone 66", UnitPrice = 3399 };
            var p6 = new Product { ProductName = "iPhone 8", UnitPrice = 6666 };
            var p7 = new Product { ProductName = "iPhone X", UnitPrice = 9999 };


            {
                ctx.Products.AddRange(p2, p3, p4, p5, p6, p7);
                ctx.SaveChanges();
                Thread.Sleep(12000);// simulate long time to add products.
            }


        }


        private static void LongTask()
        {
            Console.WriteLine("Now works both methods - LongTask & AddManyProducts ");
            Thread.Sleep(8000);
            Console.WriteLine("LongTask are finished now, second method");
        }


        public async void AddOrder(Order order)
        {
            ctx.Orders.Add(order);
            await ctx.SaveChangesAsync();
        }


        public async Task<List<Order>> GetOrdersById(List<int> orderId)
        {
            return await ctx.Orders.Where(o => orderId.Contains(o.Id)).ToListAsync();
        }

    }
}
