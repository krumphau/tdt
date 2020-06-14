using System.Text.Json;

namespace TDTapi.Auth
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            //PropertyNamingPolicy = JsonNamingPolicy.,
            IgnoreNullValues = true
        };
    }
}
