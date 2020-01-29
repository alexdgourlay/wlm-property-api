using System;
using System.Collections.Generic;
using System.Linq;
using WlmPropertyAPI.DataAccess.Contracts;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess
{
    class PpdTransactionRepository : IPpdTransactionRepository
    {
        private readonly WLMPropertyContext _dbContext;

        public PpdTransactionRepository(WLMPropertyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PpdTransaction> GetTopN(int N)
        {
            return _dbContext.PpdTransactions.Take(N);
        }

    }
}
