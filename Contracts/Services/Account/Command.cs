using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Command
    {
        public record CreateAccount(string Id, string UserName, string PassWord, string Role, string NickName) : Message, ICommand;
        public record ChangePassword(string Id, string PassWord) : Message, ICommand;
        public record DeleteAccount(string Id) : Message, ICommand;
    }
}
