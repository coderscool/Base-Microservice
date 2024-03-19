using Application.Abstractions;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListAccountInteractor : IPagedInteractor<Query.GetListAccountPaging, Projection.ListAccountUser>
    {
        private readonly IProjectionGateway<Projection.ListAccountUser> _projectionGateway;

        public GetListAccountInteractor(IProjectionGateway<Projection.ListAccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task<List<Projection.ListAccountUser>> InteractAsync(Query.GetListAccountPaging query, CancellationToken cancellationToken)
            => await _projectionGateway.FindPaginatonAsync(query.PageIndex, cancellationToken);
    } 
}
