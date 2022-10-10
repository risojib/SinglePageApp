using System;
using System.Collections.Generic;

#nullable disable

namespace Evidence.Data
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int? CountryId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PicPath { get; set; }

        public virtual Country Country { get; set; }
    }
}
