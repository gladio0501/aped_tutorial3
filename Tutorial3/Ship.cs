using System.Collections.Generic;
using Tutorial3.Containers;

namespace Tutorial3
{
    public class Ship
    {
        public string Name { get; set; }
        public double MaxCapacity { get; set; }
        public List<Container> Containers { get; set; }

        public Ship(string name, double maxCapacity)
        {
            Name = name;
            MaxCapacity = maxCapacity;
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            double currentCapacity = 0;
            foreach (var c in Containers)
            {
                currentCapacity += c.CargoMass;
            }

            if (currentCapacity + container.CargoMass > MaxCapacity)
            {
                throw new System.Exception("The ship's capacity has been exceeded.");
            }

            Containers.Add(container);
        }

        public void UnloadAllContainers()
        {
            Containers.Clear();
        }
    }
}