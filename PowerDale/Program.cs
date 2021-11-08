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
            Console.WriteLine("Press Y to view the last week's usage");
            if (Console.ReadLine().Equals("y"))
            {
                Console.WriteLine("Please enter your smart meter id");
                string idInput = Console.ReadLine();
                showLastWeekUsage(idInput);
            }
            else
            {
                
                PricePlan price = FindPricePlan("smart-meter-0", seed.pricePlans);
                decimal Cost = calculateCost(seed.smartMeters.Find(e => e.SmartMeterID == "smart-meter-0").ElectricityReadings, price);
            }
        }

        static PricePlan FindPricePlan(string smartMeterId, List<PricePlan> pricePlans)
        {
            // print price plan which linked to smart meter
            // print supplier name and unit rate
            Seed seed = new Seed();
            if (seed.SmartMeterToPricePlanAccounts.ContainsKey(smartMeterId))
            {
                var powerSupplier = seed.SmartMeterToPricePlanAccounts[smartMeterId];
                Console.WriteLine("The Smart box " + smartMeterId + " is assigned to " + powerSupplier.Name);
                var priceplan = pricePlans.Find(e => e.EnergySupplier.Name == powerSupplier.Name);

                return priceplan;
            }
            return null;
        }

        static decimal calculateCost(List<ElectricityReadings> electricityReadings, PricePlan price)
        {
            var average = calculateAverageReading(electricityReadings);
            var timeElapsed = calculateTimeElapsed(electricityReadings);
            var averagedCost = average / timeElapsed;

            return averagedCost * price.UnitRate;
        }
        static decimal calculateAverageReading(List<ElectricityReadings> electricityReadings)
        {
            var newSummedReadings = electricityReadings.Select(readings => readings.Reading).Aggregate((reading, accumulator) => reading + accumulator);

            return newSummedReadings / electricityReadings.Count();
        }
        static decimal calculateTimeElapsed(List<ElectricityReadings> electricityReadings)
        {
            var first = electricityReadings.Min(reading => reading.Time);
            var last = electricityReadings.Max(reading => reading.Time);

            return (decimal)(last - first).TotalHours;
        }

        static void showLastWeekUsage(string idInput)
        {
            Seed seed = new Seed();
            if (seed.SmartMeterToPricePlanAccounts.ContainsKey(idInput))
            {
                var weekReadings = (seed.smartMeters.Find(e => e.SmartMeterID == idInput).ElectricityReadings);
                var powerSupplier = seed.SmartMeterToPricePlanAccounts[idInput];
                var priceplan = seed.pricePlans.Find(e => e.EnergySupplier.Name == powerSupplier.Name);
                var lastweekUsage = calculateCost(weekReadings, priceplan);
                Console.WriteLine("The usage list for last week is : " + lastweekUsage);
            }
        }
    }
}  

