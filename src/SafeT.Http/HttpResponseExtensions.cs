using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SafeT.Http
{
    public static class HttpResponseExtensions
    {

        private static bool TryDeserialiseError(string json, out Error error)
        {
            try
            {
                error = JsonConvert.DeserializeObject<Error>(json);
                return true;
            }
            catch (JsonException)
            {
                error = default;
                return false;
            }
        }

        public static bool IsSuccessStatusCode(this HttpResponse me) => me.StatusCode >= 200 && me.StatusCode <= 299;
        public static async Task<Safe<T>> SafeResponse<T>(this HttpResponse me, string errorMessage, JsonConverter converter = null)
        {

            if (!me.IsSuccessStatusCode())
            {
                if (me.Body == null) return new Error() {Message = errorMessage, StatusCode = me.StatusCode};
                using var sw = new StreamReader(me.Body);

                var body = await sw.ReadToEndAsync();

                return TryDeserialiseError(body, out var val) ? val : new Error() { Message = errorMessage, StatusCode = me.StatusCode, Content = body };
            }
            else
            {
                using var sw = new StreamReader(me.Body);

                var body = await sw.ReadToEndAsync();

                return converter == null ? JsonConvert.DeserializeObject<T>(body) : JsonConvert.DeserializeObject<T>(body, converter);
            }
        }


        public static async Task<Safe<T>> SafeResponse<T>(this Task<HttpResponse> me, string errorMessage)
        {
            return await await me.ContinueWith(o => o.Result.SafeResponse<T>(errorMessage));
        }
    }
}
