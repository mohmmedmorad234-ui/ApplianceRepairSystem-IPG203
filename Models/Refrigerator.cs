using System;

namespace ApplianceRepairSystem.Models
{
    public class Refrigerator : Appliance
    {
        private int _capacityLiters;
        private bool _needsGasRefill;

        public int CapacityLiters
        {
            get { return _capacityLiters; }
            set
            {
                if (value > 0)
                    _capacityLiters = value;
                else
                    _capacityLiters = 100;
            }
        }

        public bool NeedsGasRefill
        {
            get { return _needsGasRefill; }
            set { _needsGasRefill = value; }
        }

        public Refrigerator(string serialNumber, string brand, decimal baseRepairCost, int capacityLiters, bool needsGasRefill)
            : base(serialNumber, brand, baseRepairCost)
        {
            CapacityLiters = capacityLiters;
            NeedsGasRefill = needsGasRefill;
        }

        public override decimal CalculateRepairCost()
        {
            decimal totalCost = _baseRepairCost;
            if (_needsGasRefill)
            {
                totalCost += 50m;
            }
            if (_capacityLiters > 400)
            {
                totalCost += 30m;
            }
            return totalCost;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("   Type: Refrigerator | Capacity: {0}L | Gas Refill: {1} | Total Cost: {2}$",
                _capacityLiters, _needsGasRefill ? "Yes" : "No", CalculateRepairCost());
        }
    }
}
