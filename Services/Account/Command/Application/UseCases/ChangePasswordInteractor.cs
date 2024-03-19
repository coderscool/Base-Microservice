﻿using Application.Abstractions;
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
    public class ChangePasswordInteractor : IInteractor<Command.ChangePassword>
    {
        private readonly IApplicationService _applicationService;
        public ChangePasswordInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.ChangePassword command, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Account>(command.Id, cancellationToken);
            account.Handle(command);
            await _applicationService.AppendEventsAsync(account, cancellationToken);
            account.MarkChangesAsCommitted();
        }
    }
}
