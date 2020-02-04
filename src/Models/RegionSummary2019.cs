using System;
using System.Collections.Generic;

namespace WlmPropertyAPI.Models
{
    public partial class RegionSummary2019
    {
        public string Region { get; set; }
        public long? MeanPrice { get; set; }
        public int? NumberSold { get; set; }
    }
}
