using System;
using ApplianceRepairSystem.Models;
using ApplianceRepairSystem.Services;

namespace ApplianceRepairSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            RepairCenter center = new RepairCenter("Al-Amal Maintenance Center");

            Appliance fridge = new Refrigerator("SN-1001", "Samsung", 100m, 450, true);
            Appliance washer = new WashingMachine("SN-1002", "LG", 70m, 8.0, true);
            Appliance ac = new AirConditioner("SN-1003", "Gree", 120m, 24000, true);

            center.AddAppliance(fridge);
            center.AddAppliance(washer);
            center.AddAppliance(ac);

            washer.Status = "Repaired";

            center.DisplayAllAppliances();

            Console.ReadKey();
        }
    }
}
