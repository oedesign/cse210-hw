using System;

class Program
{
    static void Main(string[] args)
    {
        // First order: USA
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.50, 2));
        order1.AddProduct(new Product("Pen", "P045", 1.75, 5));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}\n");

        // Second order: Non-USA
        Address address2 = new Address("456 King St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N011", 5.00, 3));
        order2.AddProduct(new Product("Backpack", "BP100", 30.00, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
