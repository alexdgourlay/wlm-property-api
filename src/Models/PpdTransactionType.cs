using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace WlmPropertyAPI.Models
{
    public class PpdTransactionType : ObjectGraphType<PpdTransaction>
    {
        // Field descriptions taken from .gov website, available at: https://www.gov.uk/government/statistical-data-sets/price-paid-data-downloads.
        public PpdTransactionType()
        {
            Name = "Price Paid Data includes information on all property sales in England and Wales that are sold for value and are lodged with the HM Land Registry.";
            Field(x => x.TransactionUniqueIdentifier).Description("");
            Field(x => x.Price).Description("");
            Field(x => x.DateOfTransfer).Description("");
            Field(x => x.OldNew).Description("");
            Field(x => x.Duration).Description("");
            Field(x => x.Paon).Description("");
            Field(x => x.Saon).Description("");
            Field(x => x.Street).Description("");
            Field(x => x.Locality).Description("");
            Field(x => x.TownCity).Description("");
            Field(x => x.District).Description("");
            Field(x => x.County).Description("");
            Field(x => x.PpdCategoryType).Description("");
            Field(x => x.RecordStatus).Description("");
        }
    }
}
