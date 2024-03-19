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
    public class ProjectAccountWhenPasswordChangeConsumer : Consumer<DomainEvent.PasswordChange>
    {
        public ProjectAccountWhenPasswordChangeConsumer(IInteractor<DomainEvent.PasswordChange> interactor) : base(interactor)
        {
        }
    }
}
