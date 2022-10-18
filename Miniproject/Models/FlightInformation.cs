using System;
using System.Collections.Generic;

namespace AirLinesAp.Models
{
    public partial class FlightInformation
    {
        public int FlightId { get; set; }
        public string? FlightName { get; set; }
        public int? Depature { get; set; }
        public int? Arrival { get; set; }
        public int? NoOfseats { get; set; }
        public int? Amount { get; set; }
        public DateTime? TravelDate { get; set; }
    }
}
