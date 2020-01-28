using System.Collections.Generic;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess.Contracts
{
    public interface IPpdTransactionRepository
    {
        IEnumerable<PpdTransaction> GetTopN(int N);
    }
}
