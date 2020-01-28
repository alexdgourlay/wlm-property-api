﻿using System.Collections.Generic;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.DataAccess.Contracts
{
    public interface IPpdTransactionRepository
    {
        IEnumerable<PpdTransaction> GetTop1000();
    }
}
