using Microsoft.EntityFrameworkCore;
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
        private readonly IServiceProvider _serviceProvider;

        public PpdTransactionRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<PpdTransaction> GetTopN(int N = 20)
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

        public IEnumerable<PpdTransaction> GetByYear(int year, int N = 20)
        {
            if (N <= 0) { N = 20; }

            var _dbContext = _serviceProvider.GetRequiredService<WLMPropertyContext>();

            String sqlQuery = String.Format("SELECT TOP ({0}) * FROM [dbo].[PpdTransaction{1}]", N, year);

            var res = _dbContext.PpdTransaction.FromSqlRaw(sqlQuery)
                .ToList();
            Console.WriteLine(res);

            return res;
        }
    }
}