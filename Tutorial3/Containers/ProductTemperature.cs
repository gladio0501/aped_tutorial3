using System.Collections.Generic;
using Tutorial3.Containers;

public static class ProductTemperature
{
    public static Dictionary<Product, double> RequiredTemperatures = new Dictionary<Product, double>
    {
        { Product.Bananas, 13.0 },
        { Product.Apples, 4.0 },
        { Product.Oranges, 3.0 },
        { Product.Chocolate, 18.0 }
    };
}