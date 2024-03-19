using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApi.Services;

namespace WebApi.Attributes
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeSecond;
        public CacheAttribute(int timeSecond = 1000)
        {
            _timeSecond = timeSecond;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cacheKey = GetCacheKey(context.HttpContext.Request);
            var cacheResponse = await cacheService.GetCacheAsync(cacheKey);
            if (!string.IsNullOrEmpty(cacheResponse))
            {
                var contentResult = new ContentResult()
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }
            var exitContext = await next();
            if (exitContext.Result is OkObjectResult objectResult)
            {
                await cacheService.SetCacheAsync(cacheKey, objectResult.Value, TimeSpan.FromSeconds(_timeSecond));
            }
        }
        private static string GetCacheKey(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach( var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
