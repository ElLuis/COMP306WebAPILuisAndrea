using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306WebAPILuisAndrea.Models
{
    public class DrivingCentre
    {
        [Key]
        public int AddressId { get; set; }
        public int Number { get; set; }
        public String Street1 { get; set; }
        public String Street2 { get; set; }
        public String Country { get; set; }
        public String Province { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
    }
}
