using System;
using System.Collections.Generic;

namespace AirLinesAp.Models
{
    public partial class Payment
    {
        public int Payid { get; set; }
        public string? Class { get; set; }
        public int? Seats { get; set; }
        public long? CardNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Cvv { get; set; }
    }
}
