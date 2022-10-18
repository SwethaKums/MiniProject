using System;
using System.Collections.Generic;

namespace AirLinesAp.Models
{
    public partial class Login
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public string? PassWord { get; set; }
    }
}
