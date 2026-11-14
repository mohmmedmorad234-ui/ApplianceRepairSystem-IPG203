using System;

namespace ApplianceRepairSystem.Models
{
    public class AirConditioner : Appliance
    {
        private int _btuRating;
        private bool _isInverter;

        public int BtuRating
        {
            get { return _btuRating; }
            set
            {
                if (value >= 9000)
                    _btuRating = value;
                else
                    _btuRating = 9000;
            }
        }

        public bool IsInverter
        {
            get { return _isInverter; }
            private set { _isInverter = value; }
        }

        public AirConditioner(string serialNumber, string brand, decimal baseRepairCost, int btuRating, bool isInverter)
            : base(serialNumber, brand, baseRepairCost)
        {
            BtuRating = btuRating;
            IsInverter = isInverter;
        }

        public override decimal CalculateRepairCost()
        {
            decimal totalCost = _baseRepairCost;
            if (_isInverter)
            {
                totalCost += 60m;
            }
            if (_btuRating >= 18000)
            {
                totalCost += 40m;
            }
            return totalCost;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("   Type: Air Conditioner | BTU: {0} | Inverter: {1} | Total Cost: {2}$",
                _btuRating, _isInverter ? "Yes" : "No", CalculateRepairCost());
        }
    }
}
