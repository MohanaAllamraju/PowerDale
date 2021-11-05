using System;
using System.Collections.Generic;
using System.Text;

namespace PowerDale
{
    public class SmartMeter
    {
        public string SmartMeterID;
        public List<ElectricityReadings> ElectricityReadings = new List<ElectricityReadings>();

        public SmartMeter(string smartMeterID, List<ElectricityReadings> electricityReadings)
        {
            this.SmartMeterID = smartMeterID;
            this.ElectricityReadings = electricityReadings;
        }

    }
}
