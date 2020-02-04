using System;
using System.Collections.Generic;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess.Contracts
{
    public interface IPpdTransactionRepository
    {
        IEnumerable<PpdTransaction> GetTopN(int N);

        IEnumerable<PpdTransaction> GetByYear(int year, int N);

        IEnumerable<PpdTransaction> GetByPostcode(string Postcode);

        IEnumerable<String> GetDistinctCounties();
    }
}
