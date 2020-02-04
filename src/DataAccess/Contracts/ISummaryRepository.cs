using System;
using System.Collections.Generic;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess.Contracts
{
    public interface ISummaryRepository
    {
        IEnumerable<RegionSummary2019> GetSummary();
    }
}
