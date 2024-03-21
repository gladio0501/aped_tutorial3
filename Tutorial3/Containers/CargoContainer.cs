using Tutorial3.Exceptions;

namespace Tutorial3.Containers;

public class CargoContainer : Container
{
    public CargoContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload,string serialNumber) : base(cargoMass, height, tareWeight, depth, serialNumber, maxPayload)
    {
        Type = ContainerType.Cargo;
    }

    public override void Unload()
    {
        CargoMass = 0;
    }

    public override void Load(double cargoWeight)
    {
        if (cargoWeight+CargoMass > MaxPayload)
        {
            throw new OverfillException($"Cargo weight exceeds the maximum limit of {MaxPayload} kg");
        }
        CargoMass += cargoWeight;
    }

}