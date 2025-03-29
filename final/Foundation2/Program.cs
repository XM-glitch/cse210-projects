using System;

class Program
{
    private List<Order> _orders;

    public Program()
    {
        _orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public void DisplayOrders()
    {
        if (_orders.Count() == 0)
        {
            Console.WriteLine("No orders available.");
        }
        else
        {
            foreach (Order order in _orders)
            {
                Console.Write("Packing Label:\n");
                order.GetPackingLabel();
                Console.WriteLine($"\nShipping Label:\n{order.GetShippingLabel()}\n\nTotal Cost: {order.GetTotalCost()}");
                Console.WriteLine("\n- - - - -\n");
            }            
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();

        Address customerAddress1 = new Address("123 ABC St", "Somewhere", "WA", "USA");
        Address customerAddress2 = new Address("456 DEF Ave", "Elsewhere", "SA", "Australia");

        Customer customer1 = new Customer("Jim", customerAddress1);
        Customer customer2 = new Customer("Bob", customerAddress2);

        Product product1 = new Product("Rice", "AZGEJ", 5.00, 3); // 15
        Product product2 = new Product("Beans", "ASIBJ", 2.50, 6); // 15
        Product product3 = new Product("Corn", "AJBIS", 1.50, 3); // 4.5

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        program.AddOrder(order1);

        Product product4 = new Product("Mayo", "CAJGN", 2.50, 4); // 10
        Product product5 = new Product("Mustard", "CBWJW", 1.25, 9); // 11.25
        Product product6 = new Product("Ketchup", "CBJWN", 1.50, 2); // 3

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        program.AddOrder(order2);

        Console.Clear();
        program.DisplayOrders();
    }
}