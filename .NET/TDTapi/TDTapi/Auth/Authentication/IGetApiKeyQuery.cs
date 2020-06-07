using System.Threading.Tasks;

namespace TDTapi.Auth
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
