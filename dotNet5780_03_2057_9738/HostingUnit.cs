using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_03_2057_9738
{
    public class HostingUnit
    {
        public string UnitName { get; set; }
        public int Rooms { get; set; }
        public bool IsSwimmingPool { get; set; }
        public List<DateTime> AllOrders { get; set; }
        public List<string> Uris { get; set; }
    }
}
