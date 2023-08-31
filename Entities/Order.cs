using System.Globalization;
using System.Collections.Generic;
using Teste.Entities.Enums;
using System.Text;

namespace Teste.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }

        public OrderStatus Status { get; set; }

        public Client Client { get; set; }

        List<OrderItem> items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            items.Remove(item);
        }


        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem it in items)
            {
                sum += it.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Order moment: ");
            sb.AppendLine($"{Moment.ToShortDateString()} {Moment.ToLongTimeString()}");
            sb.AppendLine($"Order status: {Status}");
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append($"({Client.BirthDate.ToShortDateString()}) - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");

            foreach (OrderItem i in items)
            {
                sb.Append(i.Product.Name + ", ");
                sb.Append($"{i.Product.Price.ToString("f2", CultureInfo.InvariantCulture)}, ");
                sb.Append("Quantity: " + i.Quantity + ", ");
                sb.AppendLine($"Subtotal: ${i.SubTotal().ToString("f2", CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine($"Total price: ${Total().ToString("f2", CultureInfo.InvariantCulture)}");

            return sb.ToString();
        }
    }
}
