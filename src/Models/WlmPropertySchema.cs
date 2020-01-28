using GraphQL;
using WlmPropertyAPI.Utilities;

namespace WlmPropertyAPI.Models
{
    public class WlmPropertySchema : GraphQL.Types.Schema
    {
        public WlmPropertySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphQLQuery>();
        }
    }
}
