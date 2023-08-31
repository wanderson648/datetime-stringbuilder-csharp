using System.Globalization;
using Teste.Entities;
using Teste.Entities.Enums;

namespace Teste
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter client data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());


            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);


            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine()); 

            for (int i=0; i<n; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data: ");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int qtd = int.Parse(Console.ReadLine());

                Product prod = new Product(prodName, prodPrice);
                OrderItem item = new OrderItem(qtd, prodPrice, prod);

                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);

        }
    }
}