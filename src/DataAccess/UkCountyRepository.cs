﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess
{
    public class UkCountyRepository : IUkCountyRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public UkCountyRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public UkCounty GetCounty(string county)
        {
            var _dbContext = _serviceProvider.GetRequiredService<WLMPropertyContext>();
            return _dbContext.UkCounty.Single(x => x.PpdCounty == county);
               
        }

        public IEnumerable<UkCounty> GetCounties()
        {
            var _dbContext = _serviceProvider.GetRequiredService<WLMPropertyContext>();
            return _dbContext.UkCounty.ToList();
        }
    }
}
