using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Account : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.CreateAccount cmd)
            => RaiseEvent<DomainEvent.AccountCreate>((version, AggregateId) => new(
                AggregateId, cmd.UserName, cmd.PassWord, cmd.Role, cmd.NickName, version));

        public void Handle(Command.ChangePassword cmd)
           => RaiseEvent<DomainEvent.PasswordChange>((version, AggregateId) => new(
               cmd.Id, cmd.PassWord, version));

        public void Handle(Command.DeleteAccount cmd)
            => RaiseEvent<DomainEvent.AccountRemove>((version, AggregateId) => new(
               cmd.Id, version));
        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
