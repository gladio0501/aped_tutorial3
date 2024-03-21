using System;
using Tutorial3.Containers;

class Program
{
    static void Main(string[] args)
    {
        //Too lazy and ill to do serial numbers right
        var cargoContainer = new CargoContainer(1000, 2.5, 500, 2.5, 2000, "CC123");
        var refrigeratedContainer = new RefrigeratedContainer(500, 2.5, 500, 2.5, 1500, 4, "RC123");
        var gasContainer = new GasContainer(200, 2.5, 500, 2.5, 1000, 1, "GC123");
        var liquidContainer = new LiquidContainer(200, 2.5, 500, 2.5, 1000,  "GC123");

        cargoContainer.Load(500);
        refrigeratedContainer.Load(Product.Apples, 200);
        gasContainer.Load(300);
        liquidContainer.Load(300, true);
        
        var ship = new Ship("Titanic", 5000);
        
        ship.AddContainer(cargoContainer);
        ship.AddContainer(refrigeratedContainer);
        ship.AddContainer(gasContainer);

        // Print the details of the ship and each container to the console
        Console.WriteLine(ship.ToString());
        
        //Test exceptions
        liquidContainer.Load(353454, true);
        try
        {
            refrigeratedContainer.Load(Product.Oranges, 200);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}