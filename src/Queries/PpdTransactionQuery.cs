using GraphQL.Types;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.Queries
{
    public class PpdTransactionQuery : ObjectGraphType
    {

        public PpdTransactionQuery(IPpdTransactionRepository ppdTransactionRepository)
        {

            Field<ListGraphType<PpdTransactionType>>(
                "PpdTransactions",
                arguments: new QueryArguments(
                            new QueryArgument<IdGraphType> { Name = "n" },
                            new QueryArgument<IdGraphType> { Name = "year" }),

                resolve: context =>
                {
                    var n = context.GetArgument<int>("n");
                    var year = context.GetArgument<int>("year");

                    if (1995 < year && year < 3000)
                    {
                        return ppdTransactionRepository.GetByYear(year, n);
                    }
                    else
                    {
                        return ppdTransactionRepository.GetTopN(n);
                    }
                }
            );

            Field<ListGraphType<StringGraphType>>(
                "DistinctCounties",
                resolve: context =>
                {
                    return ppdTransactionRepository.GetDistinctCounties();
                });

        }
    }
}
