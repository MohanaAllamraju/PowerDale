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
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 05), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 04), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 11, 03), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 02), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 01), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 31), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 30), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 29), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 28), 15));
            electricityReadings.Add(new ElectricityReadings(new DateTime(2021, 10, 27), 15));
            smartMeters.Add(new SmartMeter("smart-meter-0", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-1", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-2", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-3", electricityReadings));
            smartMeters.Add(new SmartMeter("smart-meter-4", electricityReadings));

            var suppliers = seed.PowerSuppliers;

            var pricePlans = new List<PricePlan> {
                new PricePlan{
                    EnergySupplier = suppliers[0],
                    UnitRate = 5m,
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

            Console.WriteLine("Press Y to view the last week's usage");
            if (Console.ReadLine().Equals("y"))
            {
                Console.WriteLine("Please enter your smart meter id");
                string idInput = Console.ReadLine();
                electricityReadings = showLastWeekUsage(idInput);
                for (int i = 0;  i <= electricityReadings.Count; i++)
                {
                    Console.WriteLine("The usage list for last week is : " + electricityReadings[i]);
                }
            }
            else
            {
                PricePlan price = FindPricePlan("smart-meter-0", pricePlans);
                decimal Cost = calculateCost(electricityReadings, price);
                /* Console.WriteLine("The total cost of the smart meter 0 is : " + Cost);
                 FindPricePlan("smart-meter-1", pricePlans);
                 decimal Cost1 = calculateCost(electricityReadings, price);
                 Console.WriteLine("The total cost of the smart meter 1 is : " + Cost1);
                 FindPricePlan("smart-meter-2", pricePlans);
                 Cost = calculateCost(electricityReadings, price);
                 Console.WriteLine("The total cost of the smart meter 2 is : " + Cost);
                 FindPricePlan("smart-meter-3", pricePlans);
                 Cost = calculateCost(electricityReadings, price);
                 Console.WriteLine("The total cost of the smart meter 3 is : " + Cost);
                 FindPricePlan("smart-meter-4", pricePlans);
                 Cost = calculateCost(electricityReadings, price);
                 Console.WriteLine("The total cost of the smart meter 4 is : " + Cost);*/
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
                Console.WriteLine("The Smart box " + smartMeterId + " is assigned to " +  powerSupplier.Name);
                var priceplan = pricePlans.Find(e => e.EnergySupplier.Name == powerSupplier.Name);
                return priceplan;
            }
            return null;
        }

         static decimal calculateCost(List<ElectricityReadings> electricityReadings, PricePlan price )
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

        static List<ElectricityReadings> showLastWeekUsage(string idInput) 
        {
            Seed seed = new Seed();
            if (seed.SmartMeterToPricePlanAccounts.ContainsKey(idInput))
            {
                //ar supplierName = seed.SmartMeterToPricePlanAccounts[idInput];
                    MeterReadings readings = new MeterReadings();
                    List<ElectricityReadings> weekReadings = new List<ElectricityReadings>();
                    weekReadings = readings.ElectricityReadings;
                    return weekReadings;
            }
            return null;
           
        }
    }
}
