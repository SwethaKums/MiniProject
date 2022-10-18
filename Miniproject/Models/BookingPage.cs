using System;
using System.Collections.Generic;

namespace AirLinesAp.Models
{
    public partial class BookingPage
    {
        public int BookingId { get; set; }
        public int? Departure { get; set; }
        public int? Arrival { get; set; }
        public DateTime? BookDate { get; set; }
        public DateTime? TravelDate { get; set; }
        public string? Starttime { get; set; }

        public virtual TravelLocation? ArrivalNavigation { get; set; }
        public virtual TravelLocation? DepartureNavigation { get; set; }
    }
}
