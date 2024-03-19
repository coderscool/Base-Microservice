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
    public class ProjectAccountWhenRemoveAccountConsumer : Consumer<DomainEvent.AccountRemove>
    {
        public ProjectAccountWhenRemoveAccountConsumer(IInteractor<DomainEvent.AccountRemove> interactor) : base(interactor)
        {
        }
    }
}
