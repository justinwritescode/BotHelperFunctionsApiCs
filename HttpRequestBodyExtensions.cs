namespace Backroom.Extensions;

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class HttpRequestBodyExtensions
{
    public static async Task<T> ReadRequestBodyAsAsync<T>(this HttpRequest req)
        => JsonConvert.DeserializeObject<T>(await new StreamReader(req.Body).ReadToEndAsync().ConfigureAwait(false));
}