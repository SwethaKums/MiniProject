using System;
using System.Collections.Generic;

namespace AirLinesAp.Models
{
    public partial class TravelLocation
    {
        public TravelLocation()
        {
            BookingPageArrivalNavigations = new HashSet<BookingPage>();
            BookingPageDepartureNavigations = new HashSet<BookingPage>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }

        public virtual ICollection<BookingPage> BookingPageArrivalNavigations { get; set; }
        public virtual ICollection<BookingPage> BookingPageDepartureNavigations { get; set; }
    }
}
