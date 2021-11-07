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

        public List<PricePlan> pricePlans
        {
            get
            {
                var suppliers = PowerSuppliers;
                var PricePlans = new List<PricePlan>
                {
                    new PricePlan
                    {
                        EnergySupplier = suppliers[0],
                        UnitRate = 5m,
                        PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    },
                    new PricePlan
                    {
                        EnergySupplier = suppliers[1],
                        UnitRate = 2m,
                        PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    },
                    new PricePlan
                    {
                         EnergySupplier = suppliers[2],
                        UnitRate = 1m,
                        PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    }
                };
                return pricePlans;
                
            }
        }
        
        public List<SmartMeter> smartMeters
        {
            get
            {
                List<SmartMeter> smartMeters = new List<SmartMeter>();
                List<ElectricityReadings> electricityReadings = new List<ElectricityReadings>();
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 05), 1));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 04), 2));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 03), 3));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 02), 4));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 01), 5));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 31), 6));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 30), 7));
               /* electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 29), 8));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 28), 15));
                electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 27), 15));*/
                smartMeters.Add(new SmartMeter("smart-meter-0", electricityReadings));
                smartMeters.Add(new SmartMeter("smart-meter-1", electricityReadings));
                smartMeters.Add(new SmartMeter("smart-meter-2", electricityReadings));
                smartMeters.Add(new SmartMeter("smart-meter-3", electricityReadings));
                smartMeters.Add(new SmartMeter("smart-meter-4", electricityReadings));
                return smartMeters;
            }
        }
        public List<UserDetails> Users
        {
            get
            {
                List<UserDetails> users = new List<UserDetails>();
                users.Add(new UserDetails("Sarah"));
                users.Add(new UserDetails("Peter"));
                users.Add(new UserDetails("Charlie"));
                users.Add(new UserDetails("Andrea"));
                users.Add(new UserDetails("Alex"));
                return users;
            }
        }
    }
}
