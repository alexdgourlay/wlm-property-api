using GraphQL.Types;

namespace WlmPropertyAPI.Models
{
    public class PpdTransactionType : ObjectGraphType<PpdTransaction>
    {
        // Field descriptions taken from .gov website, available at: https://www.gov.uk/government/statistical-data-sets/price-paid-data-downloads.
        public PpdTransactionType()
        {
            //Name = "Price-Paid-Data-Transaction";

            Description = "Price Paid Data includes information on all property sales in England and Wales that are sold for value and are lodged with the HM Land Registry.";

            Field(x => x.TransactionUniqueIdentifier, type: typeof(IdGraphType))
                .Description("A reference number which is generated automatically recording each published sale. The number is unique and will change each time a sale is recorded.");

            Field(x => x.Price)
                .Description("Sale price stated on the transfer deed.");

            Field(x => x.DateOfTransfer)
                .Description("Date when the sale was completed, as stated on the transfer deed.");

            Field(x => x.Postcode)
                .Description("This is the postcode used at the time of the original transaction. Note that postcodes can be reallocated and these changes are not reflected in the Price Paid Dataset.");

            Field(x => x.PropertyType)
                .Description("D = Detached, S = Semi-Detached, T = Terraced, F = Flats/Maisonettes, O = Other");

            Field(x => x.OldNew)
                .Description("Indicates the age of the property and applies to all price paid transactions, residential and non-residential. Y = a newly built property, N = an established residential building");

            Field(x => x.Duration)
                .Description("Relates to the tenure: F = Freehold, L= Leasehold etc. Note that HM Land Registry does not record leases of 7 years or less in the Price Paid Dataset.");

            Field(x => x.Paon)
                .Description("Primary Addressable Object Name. Typically the house number or name.");

            Field(x => x.Saon)
                .Description("Secondary Addressable Object Name. Where a property has been divided into separate units (for example, flats), the PAON (above) will identify the building and a SAON will be specified that identifies the separate unit/flat.");

            Field(x => x.Street).Description("");

            Field(x => x.Locality).Description("");

            Field(x => x.TownCity).Description("");

            Field(x => x.District).Description("");

            Field(x => x.County).Description("");

            Field(x => x.PpdCategoryType)
                .Description("Indicates the type of Price Paid transaction. A = Standard Price Paid entry, includes single residential property sold for value. B = Additional Price Paid entry including transfers under a power of sale / repossessions, buy - to - lets(where they can be identified by a Mortgage) and transfers to non -private individuals Note that category B does not separately identify the transaction types stated HM Land Registry has been collecting information on Category A transactions from January 1995. Category B transactions were identified from October 2013.");

            Field(x => x.RecordStatus)
                   .Description("Indicates additions, changes and deletions to the records.(see guide below). A= Addition. C = Change. D = Delete. Note that where a transaction changes category type due to misallocation(as above) it will be deleted from the original category type and added to the correct category with a new transaction unique identifier.");
        }
    }
}
