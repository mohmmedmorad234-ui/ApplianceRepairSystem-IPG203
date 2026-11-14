using System;
using System.Collections.Generic;
using ApplianceRepairSystem.Models;

namespace ApplianceRepairSystem.Services
{
    public class RepairCenter
    {
        private List<Appliance> _appliances;
        private string _centerName;

        public string CenterName
        {
            get { return _centerName; }
            private set { _centerName = value; }
        }

        public RepairCenter(string centerName)
        {
            CenterName = centerName;
            _appliances = new List<Appliance>();
        }

        public void AddAppliance(Appliance appliance)
        {
            if (appliance != null)
            {
                appliance.OnStatusChanged += HandleStatusChanged;
                _appliances.Add(appliance);
            }
        }

        private void HandleStatusChanged(Appliance appliance, string oldStatus, string newStatus)
        {
            Console.WriteLine("[Notification - {0}] Device {1} ({2}) status changed from '{3}' to '{4}'.",
                CenterName, appliance.SerialNumber, appliance.Brand, oldStatus, newStatus);
        }

        public decimal CalculateTotalRepairCost()
        {
            decimal total = 0;
            foreach (Appliance item in _appliances)
            {
                total += item.CalculateRepairCost();
            }
            return total;
        }

        public void DisplayAllAppliances()
        {
            Console.WriteLine("=== {0} - Appliances List ===", CenterName);
            foreach (Appliance item in _appliances)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("Total Repair Cost for all appliances: {0}$", CalculateTotalRepairCost());
        }
    }
}
