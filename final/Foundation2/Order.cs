using System;
using System.Reflection.Metadata.Ecma335;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }
        return total;
    }

    public void GetPackingLabel()
    {
        if (_products.Count() == 0)
        {
            Console.WriteLine("No products available.");
        }
        foreach (Product product in _products)
        {
            Console.WriteLine($"{product.GetName()} - {product.GetProductId()}");
        }
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} - {_customer.GetAddress().GetFullAddress()}";
    }
}