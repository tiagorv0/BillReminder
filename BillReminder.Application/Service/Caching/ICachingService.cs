
namespace BillReminder.Application.Service.Caching;

public interface ICachingService
{
    Task SetAsync(string key, string value);
    Task<string> GetAsync(string key);
}
