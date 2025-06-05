using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - Customer in Germany
        Address address1 = new Address("123 Apple St", "Berlin", "BE", "Germany");
        Customer customer1 = new Customer("Alice Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("USB Cable", "U001", 5.99, 3));
        order1.AddProduct(new Product("Keyboard", "K002", 45.50, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Order 2 - Customer in Japan
        Address address2 = new Address("456 Cherry Lane", "Tokyo", "Tokyo", "Japan");
        Customer customer2 = new Customer("Bob Jones", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "M003", 150.00, 1));
        order2.AddProduct(new Product("HDMI Cable", "H004", 10.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}

