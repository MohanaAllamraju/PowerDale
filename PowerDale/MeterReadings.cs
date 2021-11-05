using System;
using System.Collections.Generic;
using System.Text;

namespace PowerDale
{
    class MeterReadings
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReadings> ElectricityReadings { get; set; }
    }
}
