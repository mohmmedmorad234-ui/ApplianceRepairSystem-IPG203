using System;

namespace ApplianceRepairSystem.Validators
{
    public static class ApplianceValidator
    {
        public static bool IsValidSerialNumber(string serialNumber)
        {
            return !string.IsNullOrWhiteSpace(serialNumber) && serialNumber.StartsWith("SN-");
        }

        public static bool IsValidRepairCost(decimal cost)
        {
            return cost > 0;
        }
    }
}
