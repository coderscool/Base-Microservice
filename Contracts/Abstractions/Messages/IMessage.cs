using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.Messages
{
    [ExcludeFromTopology]
    public interface IMessage : IRequest
    {
        DateTimeOffset Timestamp { get; }
    }
}
