using GraphQL;
using WlmPropertyAPI.Queries;

namespace WlmPropertyAPI.Models
{
    public class WlmPropertySchema : GraphQL.Types.Schema
    {
        public WlmPropertySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PpdTransactionQuery>();
        }
    }
}
