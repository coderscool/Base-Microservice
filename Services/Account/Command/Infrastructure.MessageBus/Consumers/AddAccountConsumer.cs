using Application.Abstractions;
using Contracts.Services.Account;
using Infrastructure.MessageBus.Abstractions;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumer
{
    public class AddAccountConsumer : Consumer<Command.CreateAccount>
    {
        public AddAccountConsumer(IInteractor<Command.CreateAccount> interactor) : base(interactor) 
        { 
        }
    }
}
