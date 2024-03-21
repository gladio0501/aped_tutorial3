using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, double pressure, string serialNumber) : base(cargoMass, height, tareWeight, depth, serialNumber, maxPayload)
    {
        Type = ContainerType.Gas;
        Pressure = pressure;
    }

    public override void Unload()
    {
        CargoMass *= 0.05;
    }

    public override void Load(double cargoWeight)
    {
        if (cargoWeight + CargoMass > MaxPayload)
        {
            throw new OverfillException($"Cargo weight exceeds the maximum limit of {MaxPayload} kg");
        }
        CargoMass += cargoWeight;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazardous event occurred in container {SerialNumber}: {message}");
    }
}