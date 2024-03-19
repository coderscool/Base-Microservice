using Contracts.Abstractions.Messages;
using MassTransit;
using MassTransit.Initializers.PropertyProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Query
    {
        public class GetListAccount : IQuery
        {
            public string Id { get; set; }
        }
        public class GetListAccountPaging : IQuery
        {
            public int PageIndex { get; set; }
        }
        
    }
}
