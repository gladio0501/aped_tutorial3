using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }
    public  LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string serialNumber) : base(cargoMass, height, tareWeight, depth, serialNumber, maxPayload)
    {
        Type = ContainerType.Liquid;
    }
    public override void Unload()
    {
        CargoMass = 0;
    }

    public override void Load(double cargoWeight)
    {
        double maxAllowedWeight = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;

        if (cargoWeight > maxAllowedWeight)
        {
            if (IsHazardous)
            {
                NotifyHazard($"Attempted to load {cargoWeight} kg into a hazardous liquid container. This exceeds the maximum allowed weight of {maxAllowedWeight} kg.");
            }
            else
            {
                throw new OverfillException($"Cargo weight exceeds the maximum limit of {maxAllowedWeight} kg");
            }
        }

        CargoMass += cargoWeight;
    }
    

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for Container {SerialNumber}: {message}");
    }
}