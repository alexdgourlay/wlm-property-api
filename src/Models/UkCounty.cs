using System;
using System.Collections.Generic;

namespace WlmPropertyAPI.Models
{
    public partial class UkCounty
    {
        public UkCounty()
        {
            PpdTransaction = new HashSet<PpdTransaction>();
        }

        public string PpdCounty { get; set; }
        public string CeremonialOrPreservedCounty { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

        public virtual ICollection<PpdTransaction> PpdTransaction { get; set; }
    }
}
