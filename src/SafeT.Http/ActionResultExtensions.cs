using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SafeT.Http
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
            try
            {
                var r = await me;
                return r.ToIActionResult();
            }
            catch (Exception e)
            {
                return Safe<T>.Error(e).ToIActionResult();
            }
        }
        public static async Task<IActionResult> ToIActionResultAsync<T>(this Task<Safe<T>> me, HttpStatusCode successStatusCode)
        {
            try
            {
                var r = await me;
                return r.ToIActionResult(successStatusCode);
            }
            catch (Exception e)
            {
                return Safe<T>.Error(e).ToIActionResult();
            }
        }
    }
}
