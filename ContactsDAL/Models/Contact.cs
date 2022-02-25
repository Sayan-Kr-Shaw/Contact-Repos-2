using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsDAL.Models
{
    public partial class Contact
    {
        [Required]
        public string ContactId { get; set; } = null!;
        public string? Name { get; set; }
        public byte[]? Photograph { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? MarriageAnniversary { get; set; }
        public string? Notes { get; set; }
    }
}
