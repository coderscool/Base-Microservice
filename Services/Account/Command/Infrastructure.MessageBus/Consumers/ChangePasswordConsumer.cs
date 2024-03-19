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
    public class ChangePasswordConsumer : Consumer<Command.ChangePassword>
    {
        public ChangePasswordConsumer(IInteractor<Command.ChangePassword> interactor) : base(interactor)
        {
        }
    }
}
