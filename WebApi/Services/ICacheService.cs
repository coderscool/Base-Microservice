namespace WebApi.Services
{
    public interface ICacheService
    {
        Task<string> GetCacheAsync(string cacheKey);
        Task SetCacheAsync(string cacheKey, object response, TimeSpan timeOut);
    }
}
