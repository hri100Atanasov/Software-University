﻿namespace StorageMaster.Entities.Vehicles
{
    public class Van : Vehicle
    {
        private const int CAPACITY = 2;
        public Van() : base(capacity: CAPACITY)
        {
        }
    }
}
