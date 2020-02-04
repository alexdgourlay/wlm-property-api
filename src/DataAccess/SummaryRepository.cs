using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public SummaryRepository(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<RegionSummary2019> GetSummary()
        {
            var _dbContext = _serviceProvider.GetRequiredService<WLMPropertyContext>();
            return _dbContext.RegionSummary2019.ToList();
        }
    }
}
