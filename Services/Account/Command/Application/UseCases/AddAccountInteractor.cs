using Application.Abstractions;
using Application.Services;
using Contracts.Services.Account;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AddAccountInteractor : IInteractor<Command.CreateAccount>
    {
        private readonly IApplicationService _applicationService;
        public AddAccountInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.CreateAccount command, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Account>(command.Id, cancellationToken);
            account.Handle(command);
            Console.WriteLine("--account--");
            await _applicationService.AppendEventsAsync(account, cancellationToken);
            account.MarkChangesAsCommitted();
        }
    }
}
