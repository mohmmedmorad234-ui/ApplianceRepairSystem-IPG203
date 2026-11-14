using System;

namespace ApplianceRepairSystem.Models
{
    public class WashingMachine : Appliance
    {
        private double _loadCapacityKg;
        private bool _hasMotorIssue;

        public double LoadCapacityKg
        {
            get { return _loadCapacityKg; }
            set
            {
                if (value > 0)
                    _loadCapacityKg = value;
                else
                    _loadCapacityKg = 5.0;
            }
        }

        public bool HasMotorIssue
        {
            get { return _hasMotorIssue; }
            set { _hasMotorIssue = value; }
        }

        public WashingMachine(string serialNumber, string brand, decimal baseRepairCost, double loadCapacityKg, bool hasMotorIssue)
            : base(serialNumber, brand, baseRepairCost)
        {
            LoadCapacityKg = loadCapacityKg;
            HasMotorIssue = hasMotorIssue;
        }

        public override decimal CalculateRepairCost()
        {
            decimal totalCost = _baseRepairCost;
            if (_hasMotorIssue)
            {
                totalCost += 80m;
            }
            totalCost += (decimal)(_loadCapacityKg * 2.5);
            return totalCost;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("   Type: Washing Machine | Load: {0}kg | Motor Issue: {1} | Total Cost: {2}$",
                _loadCapacityKg, _hasMotorIssue ? "Yes" : "No", CalculateRepairCost());
        }
    }
}
