using Contracts.Services.Account;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public AccountController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost("id")]
        //[Cache]
        public async Task<IActionResult> GetAccountDetail([FromForm] Query.GetListAccount request)
        {
            var input = new GetAccountDetailRequest
            {
                Id = request.Id
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.GetAccountDetailsAsync(input);
            return Ok(reply);
        }
        [HttpPost("paging")]
        //[Cache]
        public async Task<IActionResult> GetListAccountPaging([FromForm] Query.GetListAccountPaging request)
        {
            var input = new GetListAccountRequest
            {
                Page = request.PageIndex
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.GetListAccountAsync(input);
            return Ok(reply);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateAccount([FromForm] Command.CreateAccount request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            await _publishEndpoint.Publish(request);
            return Ok();
        }
        [HttpPut()]
        public async Task<IActionResult> UpdatePassword([FromForm] Command.ChangePassword request)
        {
            await _publishEndpoint.Publish(request);
            return Ok();
        }
        [HttpDelete()]
        public async Task<IActionResult> RemoveAccount([FromForm] Command.DeleteAccount request)
        {
            await _publishEndpoint.Publish(request);
            return Ok();
        }
    }
}
