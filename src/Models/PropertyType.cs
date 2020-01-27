using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace UK_Property_API.Models
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType()
        {
            Field(x => x.Postcodes);
            Field(x => x.Area);
            Field(x => x.District);
            Field(x => x.Sector);
            Field(x => x.Unit);
        }
    }
}
