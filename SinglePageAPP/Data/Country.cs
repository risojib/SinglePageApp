using System;
using System.Collections.Generic;

#nullable disable

namespace Evidence.Data
{
    public partial class Country
    {
        public Country()
        {
            Contacts = new HashSet<Contact>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
