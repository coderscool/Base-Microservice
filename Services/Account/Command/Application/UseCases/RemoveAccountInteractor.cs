using Application.Abstractions;
using Application.Services;
using Contracts.Services.Account;
using Domain.Aggregates;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class RemoveAccountInteractor : IInteractor<Command.DeleteAccount>
    {
        private readonly IApplicationService _applicationService;
        public RemoveAccountInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.DeleteAccount command, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Account>(command.Id, cancellationToken);
            account.Handle(command);
            await _applicationService.AppendEventsAsync(account, cancellationToken);
            account.MarkChangesAsCommitted();
        }
    }
}
