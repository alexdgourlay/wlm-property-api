using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WlmPropertyAPI.Models
{
    public partial class PpdTransaction
    {
        [Key]
        public Guid TransactionUniqueIdentifier { get; set; }
        public long Price { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public string Postcode { get; set; }
        public string PropertyType { get; set; }
        public string OldNew { get; set; }
        public string Duration { get; set; }
        public string Paon { get; set; }
        public string Saon { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public string TownCity { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string PpdCategoryType { get; set; }
        public string RecordStatus { get; set; }
    }
}
