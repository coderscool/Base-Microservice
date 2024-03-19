using Application.Abstractions;
using Contracts.Services.Account;
using Grpc.Core;
using GrpcService1;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GrpcService1.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly IInteractor<Query.GetListAccount, Projection.ListAccountUser> _getAccountDetails;
        private readonly IPagedInteractor<Query.GetListAccountPaging, Projection.ListAccountUser> _getListAccount;
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger,
                              IInteractor<Query.GetListAccount, Projection.ListAccountUser> getAccountDetails,
                              IPagedInteractor<Query.GetListAccountPaging, Projection.ListAccountUser> getListAccount)
        {
            _logger = logger;
            _getAccountDetails = getAccountDetails;
            _getListAccount = getListAccount;
        }
        public override async Task<GetAccountDetailReply> GetAccountDetails(GetAccountDetailRequest request, ServerCallContext context)
        {
            var query = new Query.GetListAccount
            {
                Id = request.Id,
            };
            var result = await _getAccountDetails.InteractAsync(query, context.CancellationToken);
            if (result == null)
            {
                return await Task.FromResult(new GetAccountDetailReply
                {
                    NickName = "456",
                    PassWord = "456",
                    UserName = "456",
                    Role = "456"
                });
            }
            return await Task.FromResult( new GetAccountDetailReply
            {
                NickName = result.NickName,
                PassWord = result.PassWord,
                UserName = result.UserName,
                Role = result.Role
            });
        }
        public override async Task<GetListAccountReply> GetListAccount(GetListAccountRequest request, ServerCallContext context)
        {
            var query = new Query.GetListAccountPaging
            {
                PageIndex = request.Page
            };
            if(query == null)
            {
                throw new ArgumentNullException("query");
            }
            var result = await _getListAccount.InteractAsync(query, context.CancellationToken);
            var account = result.Select(x => new GetAccountDetailReply
            {
                UserName = x.UserName,
                PassWord = x.PassWord,
                NickName = x.NickName,
                Role = x.Role
            });
            return await Task.FromResult(new GetListAccountReply
            {
                Page = request.Page,
                Account = {account}
            });
        }
    }
}