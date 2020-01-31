using System.Collections.Generic;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess.Contracts
{
    public interface IUkCountyRepository
    {
        IEnumerable<UkCounty> GetCounties();

        UkCounty GetCounty(string county);
    }
}
