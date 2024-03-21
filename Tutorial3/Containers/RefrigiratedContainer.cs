using Tutorial3.Exceptions;
using Tutorial3.Containers;

namespace Tutorial3.Containers;

public class RefrigeratedContainer : Container
{
    public Product Product { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, Product product, double temperature,string serialNumber) : base(cargoMass, height, tareWeight, depth,serialNumber, maxPayload)
    {
        Type = ContainerType.Refrigerated;
        Product = product;
        Temperature = temperature;
    }

    public override void Unload()
    {
        CargoMass = 0;
    }

    public override void Load(double cargoWeight)
    {
        if (Temperature < ProductTemperature.RequiredTemperatures[Product])
        {
            throw new Exception($"The current temperature of {Temperature}°C is lower than the required temperature of {ProductTemperature.RequiredTemperatures[Product]}°C for {Product}");
        }

        if (cargoWeight + CargoMass > MaxPayload)
        {
            throw new OverfillException($"Cargo weight exceeds the maximum limit of {MaxPayload} kg");
        }
        CargoMass += cargoWeight;
    }
}