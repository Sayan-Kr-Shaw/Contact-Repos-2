using System;
using System.Collections.Generic;

namespace ContactsDAL.Models
{
    public partial class EmailId
    {
        public string? ContactId { get; set; }
        public string? EmailId1 { get; set; }

        public virtual Contact? Contact { get; set; }
    }
}
