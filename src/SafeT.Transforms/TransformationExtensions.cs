using System;
using System.Threading.Tasks;

namespace SafeT.Transforms
{
    public static class TransformationExtensions
    {
        public static Safe<T> ToSafe<T>(this T me)
        {
            return me;
        }

        public static Safe<TNew> Transform<TOld, TNew>(this Safe<TOld> from, Func<TOld, TNew> func)
        {
            if (from.IsError) return from.AsError;
            try
            {
                return func(from.AsSuccess);
            }
            catch (Exception e)
            {
                return new Error() { StatusCode = 500, Message = e.Message, Content =  e , Offenders = new object[] { from } };
            }
        }

        public static async Task<Safe<TNew>> TransformAsync<TOld, TNew>(this Task<Safe<TOld>> from, Func<TOld, TNew> func)
        {
            return await from.ContinueWith(o => o.Result.Transform(func));
        }

        public static async Task<Safe<TNew>> TransformAsync<TOld, TNew>(this Safe<TOld> from, Func<TOld, Task<TNew>> func)
        {
            return await func(from);
        }

        public static async Task<Safe<TNew>> TransformAsync<TOld, TNew>(this Task<Safe<TOld>> from, Func<TOld, Task<TNew>> func)
        {
            var a = await from;
            return await a.TransformAsync(func);
        }
    }
}
