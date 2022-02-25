using System;
using System.Collections.Generic;

namespace ContactsDAL.Models
{
    public partial class TelephoneNumber
    {
        public string? ContactId { get; set; }
        public decimal? TelephoneNumber1 { get; set; }
        public string? Classification { get; set; }

        public virtual Contact? Contact { get; set; }
    }
}
