using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Safe.Http
{
    public static class ActionResultExtensions
    {
        public static IActionResult ToIActionResult<T>(this Safe<T> me)
        {
            return me.IsSuccess
                ? new OkObjectResult(me.AsSuccess)
                : new ObjectResult(me.AsError) {StatusCode = me.AsError.StatusCode};

        }
        public static IActionResult ToIActionResult<T>(this Safe<T> me, HttpStatusCode successStatusCode)
        {
            return me.IsSuccess
                ? new ObjectResult(me.AsSuccess) {StatusCode = (int)successStatusCode}
                : new ObjectResult(me.AsError) { StatusCode = me.AsError.StatusCode };

        }

        public static async Task<IActionResult> ToIActionResultAsync<T>(this Task<Safe<T>> me)
        {
            return await me.ContinueWith(o => o.Result.ToIActionResult());
        }
        public static async Task<IActionResult> ToIActionResultAsync<T>(this Task<Safe<T>> me, HttpStatusCode successStatusCode)
        {
            return await me.ContinueWith(o => o.Result.ToIActionResult(successStatusCode));
        }
    }
}
