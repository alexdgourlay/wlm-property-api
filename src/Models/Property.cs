using System;
using System.ComponentModel.DataAnnotations;

namespace UK_Property_API.Models
{
    public class Property
    {
        [Key]
        public String Postcodes { get; set; }

        public String Area { get; set; }
        public String District { get; set; }
        public String Sector { get; set; }
        public String Unit { get; set; }
    }
}
