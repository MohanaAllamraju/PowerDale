using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerDale
{
    class Program
    {
    static void Main()
        {

            Seed seed = new Seed();
            List<UserDetails> userDetails = new List<UserDetails>();
            userDetails.Add(new UserDetails("Sarah"));
            userDetails.Add(new UserDetails("Peter"));
            userDetails.Add(new UserDetails("Charlie"));
            userDetails.Add(new UserDetails("Andrea"));
            userDetails.Add(new UserDetails("Alex"));

            List<SmartMeter> smartMeters = new List<SmartMeter>();
            List<ElectricityReadings> electricityReadings = new List<ElectricityReadings>();
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 03), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 02), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 01), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 31), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 30), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 29), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 28), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 27), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 26), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 25), 15));
            smartMeters.Add(new SmartMeter("smart-meter-0", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-1", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-2", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-3", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-4", electricityReadings));

            var suppliers = seed.PowerSuppliers;

            var pricePlans = new List<PricePlan> {
                new PricePlan{
                    EnergySupplier = suppliers[0],
                    UnitRate = 10m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    EnergySupplier = suppliers[1],
                    UnitRate = 2m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan{
                    EnergySupplier = suppliers[2],
                    UnitRate = 1m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                }
            };

            FindPricePlan("smart-meter-0", pricePlans);
            FindPricePlan("smart-meter-1", pricePlans);
            FindPricePlan("smart-meter-2", pricePlans);
            FindPricePlan("smart-meter-3", pricePlans);
            FindPricePlan("smart-meter-4", pricePlans);
        }

        static void FindPricePlan(string smartMeterId, List<PricePlan> pricePlans)
        {
            // print price plan which linked to smart meter
            // print supplier name and unit rate
            Seed seed = new Seed();
            if (seed.SmartMeterToPricePlanAccounts.ContainsKey(smartMeterId))
            {
                var powerSupplier = seed.SmartMeterToPricePlanAccounts[smartMeterId];
                Console.WriteLine("The Smart box " + smartMeterId + " is assigned to " +  powerSupplier.Name);
                var priceplan = pricePlans.Find(e => e.EnergySupplier.Name == powerSupplier.Name);
                Console.WriteLine("The price plan for " + smartMeterId + "the smartbox is :" +priceplan.UnitRate);
            }
           
        }

        private decimal calculateCost(List<ElectricityReadings> electricityReadings, PricePlan pricePlan)
        {
            var average = calculateAverageReading(electricityReadings);
            var timeElapsed = calculateTimeElapsed(electricityReadings);
            var averagedCost = average / timeElapsed;
            return averagedCost * pricePlan.UnitRate;
        }
        private decimal calculateAverageReading(List<ElectricityReadings> electricityReadings)
        {
            var newSummedReadings = electricityReadings.Select(readings => readings.Reading).Aggregate((reading, accumulator) => reading + accumulator);

            return newSummedReadings / electricityReadings.Count();
        }
        private decimal calculateTimeElapsed(List<ElectricityReadings> electricityReadings)
        {
            var first = electricityReadings.Min(reading => reading.Time);
            var last = electricityReadings.Max(reading => reading.Time);

            return (decimal)(last - first).TotalHours;
        }
    }
}
