using GraphQL.Types;

namespace WlmPropertyAPI.Models
{
    public class UkCountyType : ObjectGraphType<UkCounty>
    {
        public UkCountyType()
        {
            Name = "UkCounty";

            Field(x => x.PpdCounty);
            Field(x => x.CeremonialOrPreservedCounty);
            Field(x => x.Country);
            Field(x => x.Region);

            Field(
                name: "PpdTransactions",
                type: typeof(ListGraphType<PpdTransactionType>),
                resolve: context => context.Source.PpdTransaction);

        }
    }
}
