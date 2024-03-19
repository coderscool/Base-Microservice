using Application.Abstractions;
using Contracts.Services.Account;
using Infratructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infratructure.EventBus.Consumers
{
    public class ProjectAccountWhenCreateAccountConsumer : Consumer<DomainEvent.AccountCreate>
    {

        public ProjectAccountWhenCreateAccountConsumer(IInteractor<DomainEvent.AccountCreate> interactor) : base(interactor)
        {

        }
    }
}
