using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapAssignment.Models
{
    public class BootStrap
    {
        public int Bus_ID { get; set; }
        public string BoardingPoint { get; set; }
        public System.DateTime TravelDate { get; set; }
        public decimal Amount { get; set; }
        public Nullable<int> Rating { get; set; }
    }
}
