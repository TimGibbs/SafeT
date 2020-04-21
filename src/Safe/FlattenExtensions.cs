using System.Threading.Tasks;

namespace Safe
{
    public static class FlattenExtensions
    {
        public static Safe<T> Flatten<T>(this Safe<Safe<T>> me)
        {
            return me.IsError ? me.AsError : me.AsSuccess;
        }
        public static async Task<Safe<T>> FlattenAsync<T>(this Task<Safe<Safe<T>>> me)
        {
            return await me.ContinueWith(o => o.Result.Flatten());
        }
        public static async Task<Safe<T>> FlattenAsync<T>(this Safe<Task<Safe<T>>> me)
        {
            return me.IsError ? me.AsError : await me.AsSuccess;
        }
    }
}
