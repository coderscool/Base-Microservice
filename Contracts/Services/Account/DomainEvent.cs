using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class DomainEvent
    {
        public record AccountCreate(string AggregateId, string UserName, string PassWord, string Role, string NickName, long Version) : Message, IDomainEvent;
        public record PasswordChange(string AggregateId, string Password, long Version) : Message, IDomainEvent;
        public record AccountRemove(string AggregateId, long Version) : Message, IDomainEvent; 
    }
}
