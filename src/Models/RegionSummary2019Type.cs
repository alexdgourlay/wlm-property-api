using GraphQL.Types;

namespace WlmPropertyAPI.Models
{
    public class RegionSummary2019Type : ObjectGraphType<RegionSummary2019>
    { 
        public RegionSummary2019Type()
        {
            Name = "RegionSummary2019";

            Field(x => x.Region);
            Field(x => x.MeanPrice, type: typeof(FloatGraphType));
            Field(x => x.NumberSold, type: typeof(IntGraphType));
        }
    }
}
