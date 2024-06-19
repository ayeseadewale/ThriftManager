using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftManager.DTO.Requests
{
    public class MakeContributionRequest
    {
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
    }
}
