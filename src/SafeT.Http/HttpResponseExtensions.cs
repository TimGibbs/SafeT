using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SafeT.Http
{
    public static class HttpResponseExtensions
    {

        private static bool TryDeserializeError(Stream stream, out Error error)
        {
            try
            {
                error = DeserializeJsonFromStream<Error>(stream);
                return true;
            }
            catch (JsonException)
            {
                error = default;
                return false;
            }
        }

        private static T DeserializeJsonFromStream<T>(Stream stream, JsonConverter converter = null)
        {
            if (stream == null || stream.CanRead == false) return default;

            using var sr = new  StreamReader(stream);
            using var jtr = new  JsonTextReader(sr);
            var js = new JsonSerializer();
            if(converter != null)
                js.Converters.Add(converter);
            return js.Deserialize<T>(jtr);
        }

        public static bool IsSuccessStatusCode(this HttpResponse me) => me.StatusCode >= 200 && me.StatusCode <= 299;
        public static async Task<Safe<T>> SafeResponse<T>(this HttpResponse me, string errorMessage, JsonConverter converter = null)
        {
            if (me.IsSuccessStatusCode()) 
                return DeserializeJsonFromStream<T>(me.Body, converter);
            
            if (me.Body == null) 
                return new Error() {Message = errorMessage, StatusCode = me.StatusCode};

            return TryDeserializeError(me.Body, out var val) 
                ? val 
                : new Error() { Message = errorMessage, StatusCode = me.StatusCode, Content = await new StreamReader(me.Body).ReadToEndAsync() };

        }


        public static async Task<Safe<T>> SafeResponse<T>(this Task<HttpResponse> me, string errorMessage)
        {
            try
            {
                var r = await me;
                return await me.SafeResponse<T>(errorMessage);
            }
            catch (Exception e)
            {
                return (Error) e;
            }
        }
    }
}
