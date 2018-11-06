﻿using StorageMaster.Entities.Vehicles;
using System;

namespace StorageMaster.Entities.Factories
{
   public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "Semi":
                    return new Semi();
                case "Truck":
                    return new Truck();
                case "Van":
                    return new Van();
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
