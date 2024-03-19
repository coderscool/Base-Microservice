using Application.Abstractions;
using Contracts.Services.Account;
using MassTransit.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetAccountDetailsInteractor : IInteractor<Query.GetListAccount, Projection.ListAccountUser>
    {
        private readonly IProjectionGateway<Projection.ListAccountUser> _projectionGateway;

        public GetAccountDetailsInteractor(IProjectionGateway<Projection.ListAccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.ListAccountUser?> InteractAsync(Query.GetListAccount query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(item => item.AggregateId == query.Id, cancellationToken);
    }
}
