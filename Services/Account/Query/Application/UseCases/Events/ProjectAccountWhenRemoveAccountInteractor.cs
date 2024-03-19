using Application.Abstractions;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectAccountWhenRemoveAccountInteractor : IInteractor<DomainEvent.AccountRemove>
    {
        private readonly IProjectionGateway<Projection.ListAccountUser> _projectionGateway;

        public ProjectAccountWhenRemoveAccountInteractor(IProjectionGateway<Projection.ListAccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public Task InteractAsync(DomainEvent.AccountRemove @event, CancellationToken cancellationToken)
            => _projectionGateway.DeleteAsync(x => x.AggregateId == @event.AggregateId, cancellationToken); 
    }
}
