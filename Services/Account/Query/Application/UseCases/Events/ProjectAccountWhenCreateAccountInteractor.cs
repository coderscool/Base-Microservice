using Application.Abstractions;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectAccountWhenPasswordChangesInteractor : IInteractor<DomainEvent.AccountCreate>
    {
        private readonly IProjectionGateway<Projection.ListAccountUser> _projectionGateway;

        public ProjectAccountWhenPasswordChangesInteractor(IProjectionGateway<Projection.ListAccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.AccountCreate @event, CancellationToken cancellationToken)
        {
            var listAccountUser = new Projection.ListAccountUser
            {
                AggregateId = @event.AggregateId,
                UserName = @event.UserName,
                PassWord = @event.PassWord,
                Role = @event.Role,
                NickName = @event.NickName
            };
            Console.WriteLine(listAccountUser.ToString());
            await _projectionGateway.ReplaceInsertAsync(listAccountUser, cancellationToken);
        }
    }
}
