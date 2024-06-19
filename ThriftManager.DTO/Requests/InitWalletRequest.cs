using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftManager.Domain.ValueObjects;

namespace ThriftManager.DTO.Requests
{
    public class InitWalletRequest
    {
        public string Title { get; set; } = default!;
        public string WalletNumber { get; set; } = default!;
        public BankAccount Account { get; set; } = default!;
    }
}
