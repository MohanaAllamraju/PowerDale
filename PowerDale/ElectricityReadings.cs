using System;
using System.Collections.Generic;
using System.Text;

namespace PowerDale
{
    public class ElectricityReadings
    {
        public DateTime Time { get; set; }
        public Decimal Reading { get; set; }

        public ElectricityReadings(DateTime time , Decimal reading)
        {
            this.Time = time;
            this.Reading = reading;
        }
    }
}
