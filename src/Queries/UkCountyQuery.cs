using GraphQL.Types;
using System;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.Queries
{
    public class UkCountyQuery : ObjectGraphType
    {
        public UkCountyQuery(IUkCountyRepository ukCountyRepository)
        {
            Field<ListGraphType<UkCountyType>>(
                "UkCounties",
                resolve: context =>
                {
                    Console.WriteLine("Hello");
                    return ukCountyRepository.GetCounties();
                }
            );
        }
    }
}
