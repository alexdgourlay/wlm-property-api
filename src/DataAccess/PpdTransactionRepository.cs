using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess
{
    class PpdTransactionRepository : IPpdTransactionRepository
    {
        //private readonly WlmPropertyContext _dbContext;
        private readonly IServiceProvider _serviceProvider;


        public PpdTransactionRepository(IServiceProvider serviceProvider)
        {
            //_dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<PpdTransaction> GetTopN(int N)
        {
            var _dbContext = _serviceProvider.GetRequiredService<WLMPropertyContext>();
            return _dbContext.PpdTransaction.Take(N);
        }

        public IEnumerable<String> GetDistinctCounties()
        {
            return GetTopN(2000).Select(x => x.County).Distinct();
        }

        public IEnumerable<PpdTransaction> GetByPostcode(string Postcode)
        {
            throw new NotImplementedException();
        }
    }
}
