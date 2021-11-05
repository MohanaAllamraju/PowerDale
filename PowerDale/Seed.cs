using System;
using System.Collections.Generic;
using System.Text;

namespace PowerDale
{
    class Seed
    {
        public Dictionary<String, PowerSupplier> SmartMeterToPricePlanAccounts
        {
            get
            {
                Dictionary<String, PowerSupplier> smartMeterToPricePlanAccounts = new Dictionary<string, PowerSupplier>();
                smartMeterToPricePlanAccounts.Add("smart-meter-0", PowerSuppliers[0]);
                smartMeterToPricePlanAccounts.Add("smart-meter-1", PowerSuppliers[1]);
                smartMeterToPricePlanAccounts.Add("smart-meter-2", PowerSuppliers[2]);
                smartMeterToPricePlanAccounts.Add("smart-meter-3", PowerSuppliers[0]);
                smartMeterToPricePlanAccounts.Add("smart-meter-4", PowerSuppliers[1]);
                return smartMeterToPricePlanAccounts;
            }
        }

        public List<PowerSupplier> PowerSuppliers
        {
            get
            {
                List<PowerSupplier> supplier = new List<PowerSupplier>();
                supplier.Add(new PowerSupplier("Dr Evil's Dark Energy"));
                supplier.Add(new PowerSupplier("The Green Eco"));
                supplier.Add(new PowerSupplier("Power for Everyone"));
                return supplier;
            }
        }
    }
}
