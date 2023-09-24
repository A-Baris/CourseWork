using Northwind.BLL.DTOs;
using Northwind.DAL.Models.Context;
using Test;


class Program
{
    static void Main()
    {
        using (var context = new NorthwindContext()) // Create an instance of NorthwindContext
        {
            var testClass = new TestClass(context); // Provide the context to the constructor
            // Rest of your code

            foreach (var item in testClass.GetOrdersInYear(1996))
            {
                Console.WriteLine(item.ShipCountry + " " + item.TotalOrders + " " + item.OrderDate);
            }
        }
    }
}