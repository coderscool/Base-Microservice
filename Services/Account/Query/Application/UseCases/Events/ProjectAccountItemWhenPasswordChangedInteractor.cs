using Application.Abstractions;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectAccountItemWhenPasswordChangedInteractor : IInteractor<DomainEvent.PasswordChange>
    {
        private readonly IProjectionGateway<Projection.ListAccountUser> _projectGateway;
        public ProjectAccountItemWhenPasswordChangedInteractor(IProjectionGateway<Projection.ListAccountUser> projectGateway)
        {
            _projectGateway = projectGateway;
        }
        public async Task InteractAsync(DomainEvent.PasswordChange @event, CancellationToken cancellationToken)
        {
            var account = await _projectGateway.FindAsync(x => x.AggregateId == @event.AggregateId, cancellationToken);
            Console.WriteLine("success");
            if(account == null)
            {
                throw new ArgumentException("Fail");
            }
            account.PassWord = @event.Password;
            await _projectGateway.UpdateFieldAsync(x => x.AggregateId == @event.AggregateId, account, cancellationToken);
        }
    }
}
