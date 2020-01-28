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
                            new QueryArgument<IdGraphType> { Name = "n" }),

                resolve: context =>
                {
                    var n = context.GetArgument<int>("n");
                    return ppdTransactionRepository.GetTopN(n);
                }
            );
        }
    }
}
