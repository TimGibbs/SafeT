using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeT
{
    public static class CombinationExtensions
    {
        public static Safe<IEnumerable<T>> Combine<T>(this IEnumerable<Safe<T>> items, string defaultMessage = "combination error", int defaultStatusCode = 500)
        {
            var errors = items.Where(o => o.IsError).Select(o => o.AsError).ToArray();
            if (!errors.Any()) return items.Select(o => o.AsSuccess).ToArray();

            var messages = errors.Select(o => o.Message).Distinct().ToArray();
            var statusCode = errors.Select(o => o.StatusCode).Distinct().ToArray();
            return new Error()
            {
                StatusCode = statusCode.Count() == 1 ? statusCode.Single() : defaultStatusCode,
                Message = messages.Count() == 1 ? messages.Single() : defaultMessage,
                Content = errors.Select(o => o.Content),
                Offenders = errors.SelectMany(o=>o.Offenders),
            };
        }
        public static Safe<IEnumerable<T>> CombineMany<T>(this IEnumerable<Safe<IEnumerable<T>>> items, string defaultMessage = "combination error", int defaultStatusCode = 500)
        {
            var errors = items.Where(o => o.IsError).Select(o => o.AsError).ToArray();
            if (!errors.Any()) return items.SelectMany(o => o.AsSuccess).ToArray();

            var messages = errors.Select(o => o.Message).Distinct().ToArray();
            var statusCode = errors.Select(o => o.StatusCode).Distinct().ToArray();
            return new Error()
            {
                StatusCode = statusCode.Count() == 1 ? statusCode.Single() : defaultStatusCode,
                Message = messages.Count() == 1 ? messages.Single() : defaultMessage,
                Content = errors.Select(o => o.Content),
                Offenders = errors.SelectMany(o => o.Offenders),
            };
        }

        public static Task<Safe<IEnumerable<T>>> CombineAsync<T>(this IEnumerable<Task<Safe<T>>> items,string defaultMessage = "combination error", int defaultStatusCode = 500)
        {
            return Task.WhenAll(items).ContinueWith(o => o.Result.Combine(defaultMessage, defaultStatusCode));
        }

        public static Task<Safe<IEnumerable<T>>> CombineManyAsync<T>(this IEnumerable<Task<Safe<IEnumerable<T>>>> items, string defaultMessage = "combination error", int defaultStatusCode = 500)
        {
            return Task.WhenAll(items).ContinueWith(o => o.Result.CombineMany(defaultMessage, defaultStatusCode));
        }
    }
}