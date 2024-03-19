using Application.Abstractions;
using Contracts.Services.Account;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class RemoveAccountConsumer : Consumer<Command.DeleteAccount>
    {
        public RemoveAccountConsumer(IInteractor<Command.DeleteAccount> interactor) : base(interactor)
        {
        }
    }
}
