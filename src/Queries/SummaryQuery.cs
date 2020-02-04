using GraphQL.Types;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.Queries
{
    public class SummaryQuery : ObjectGraphType
    {

        public SummaryQuery(ISummaryRepository summaryRepository)
        {
            Field<ListGraphType<RegionSummary2019Type>>(
            "Summary",
            resolve: (context) =>
            {
                return summaryRepository.GetSummary();
            });

        }
    }
}
