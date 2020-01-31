using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WlmPropertyAPI.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }


        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine();
            if (!string.IsNullOrWhiteSpace(OperationName))
            {
                builder.AppendLine($"OperationName {OperationName}");
            }
            if (!string.IsNullOrWhiteSpace(NamedQuery))
            {
                builder.AppendLine($"NamedQuery {NamedQuery}");
            }
            if (!string.IsNullOrWhiteSpace(Query))
            {
                builder.AppendLine($"Query {Query}");
            }
            if (!string.IsNullOrWhiteSpace(JsonConvert.SerializeObject(Variables)))
            {
                builder.AppendLine($"Variables {JsonConvert.SerializeObject(Variables)}");
            }

            return builder.ToString();
        }
    }
}
