using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence.ViewModels
{
    public class VmContact
    {
        public int ContactId { get; set; }
        [Display(Name ="Contact Name")]
        public string ContactName { get; set; }
        public int? CountryId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IFormFile PicPath { get; set; }

    }
}
