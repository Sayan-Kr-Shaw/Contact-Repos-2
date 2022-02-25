using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDAL.Models
{
    public  class ContactDetails
    {
        [Key]
        public string ContactId { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? MarriageAnniversary { get; set; }

        public string? EmailId1 { get; set; }
    }
}
