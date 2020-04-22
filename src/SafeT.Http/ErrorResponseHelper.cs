using System.Net;

namespace SafeT.Http
{
    public static class ErrorResponseHelper
    {
        public static Error BadRequest(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.BadRequest, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> BadRequest<T>(string message, object content = null, params object[] offenders)
        {
            return BadRequest(message, content, offenders);
        }

        public static Error Unauthorized(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.Unauthorized, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> Unauthorized<T>(string message, object content = null, params object[] offenders)
        {
            return Unauthorized(message, content, offenders);
        }

        public static Error PaymentRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.PaymentRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> PaymentRequired<T>(string message, object content = null, params object[] offenders)
        {
            return PaymentRequired(message, content, offenders);
        }

        public static Error Forbidden(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.Forbidden, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> Forbidden<T>(string message, object content = null, params object[] offenders)
        {
            return Forbidden(message, content, offenders);
        }

        public static Error NotFound(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.NotFound, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NotFound<T>(string message, object content = null, params object[] offenders)
        {
            return NotFound(message, content, offenders);
        }

        public static Error MethodNotAllowed(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.MethodNotAllowed, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> MethodNotAllowed<T>(string message, object content = null, params object[] offenders)
        {
            return MethodNotAllowed(message, content, offenders);
        }

        public static Error NotAcceptable(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.NotAcceptable, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NotAcceptable<T>(string message, object content = null, params object[] offenders)
        {
            return NotAcceptable(message, content, offenders);
        }

        public static Error ProxyAuthenticationRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.ProxyAuthenticationRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ProxyAuthenticationRequired<T>(string message, object content = null, params object[] offenders)
        {
            return ProxyAuthenticationRequired(message, content, offenders);
        }

        public static Error RequestTimeout(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.RequestTimeout, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> RequestTimeout<T>(string message, object content = null, params object[] offenders)
        {
            return RequestTimeout(message, content, offenders);
        }

        public static Error Conflict(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.Conflict, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> Conflict<T>(string message, object content = null, params object[] offenders)
        {
            return Conflict(message, content, offenders);
        }

        public static Error Gone(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.Gone, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> Gone<T>(string message, object content = null, params object[] offenders)
        {
            return Gone(message, content, offenders);
        }

        public static Error LengthRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.LengthRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> LengthRequired<T>(string message, object content = null, params object[] offenders)
        {
            return LengthRequired(message, content, offenders);
        }

        public static Error PreconditionFailed(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.PreconditionFailed, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> PreconditionFailed<T>(string message, object content = null, params object[] offenders)
        {
            return PreconditionFailed(message, content, offenders);
        }

        public static Error PayloadTooLarge(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 413, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> PayloadTooLarge<T>(string message, object content = null, params object[] offenders)
        {
            return PayloadTooLarge(message, content, offenders);
        }

        public static Error RequestUriTooLong(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 414, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> RequestUriTooLong<T>(string message, object content = null, params object[] offenders)
        {
            return RequestUriTooLong(message, content, offenders);
        }

        public static Error UnsupportedMediaType(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.UnsupportedMediaType, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> UnsupportedMediaType<T>(string message, object content = null, params object[] offenders)
        {
            return UnsupportedMediaType(message, content, offenders);
        }

        public static Error RequestedRangeNotSatisfiable(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.RequestedRangeNotSatisfiable, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> RequestedRangeNotSatisfiable<T>(string message, object content = null, params object[] offenders)
        {
            return RequestedRangeNotSatisfiable(message, content, offenders);
        }

        public static Error ExpectationFailed(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.ExpectationFailed, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ExpectationFailed<T>(string message, object content = null, params object[] offenders)
        {
            return ExpectationFailed(message, content, offenders);
        }

        public static Error ImATeapot(string message, object content = null, params object[] offenders)
        {
            return new Error() {StatusCode = 418, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ImATeapot<T>(string message, object content = null, params object[] offenders)
        {
            return ImATeapot(message, content, offenders);
        }

        public static Error MisdirectedRequest(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.MisdirectedRequest, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> MisdirectedRequest<T>(string message, object content = null, params object[] offenders)
        {
            return MisdirectedRequest(message, content, offenders);
        }

        public static Error UnprocessableEntity(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.UnprocessableEntity, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> UnprocessableEntity<T>(string message, object content = null, params object[] offenders)
        {
            return UnprocessableEntity(message, content, offenders);
        }

        public static Error Locked(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.Locked, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> Locked<T>(string message, object content = null, params object[] offenders)
        {
            return Locked(message, content, offenders);
        }

        public static Error FailedDependency(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.FailedDependency, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> FailedDependency<T>(string message, object content = null, params object[] offenders)
        {
            return FailedDependency(message, content, offenders);
        }

        public static Error TooEarly(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 425, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> TooEarly<T>(string message, object content = null, params object[] offenders)
        {
            return TooEarly(message, content, offenders);
        }
        public static Error UpgradeRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.UpgradeRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> UpgradeRequired<T>(string message, object content = null, params object[] offenders)
        {
            return UpgradeRequired(message, content, offenders);
        }

        public static Error PreconditionRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.PreconditionRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> PreconditionRequired<T>(string message, object content = null, params object[] offenders)
        {
            return PreconditionRequired(message, content, offenders);
        }

        public static Error TooManyRequests(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.TooManyRequests, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> TooManyRequests<T>(string message, object content = null, params object[] offenders)
        {
            return TooManyRequests(message, content, offenders);
        }

        public static Error RequestHeaderFieldsTooLarge(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.RequestHeaderFieldsTooLarge, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> RequestHeaderFieldsTooLarge<T>(string message, object content = null, params object[] offenders)
        {
            return RequestHeaderFieldsTooLarge(message, content, offenders);
        }

        public static Error ConnectionClosedWithoutResponse(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 444, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ConnectionClosedWithoutResponse<T>(string message, object content = null, params object[] offenders)
        {
            return ConnectionClosedWithoutResponse(message, content, offenders);
        }

        public static Error UnavailableForLegalReasons(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.UnavailableForLegalReasons, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> UnavailableForLegalReasons<T>(string message, object content = null, params object[] offenders)
        {
            return UnavailableForLegalReasons(message, content, offenders);
        }

        public static Error ClientClosedRequest(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 499, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ClientClosedRequest<T>(string message, object content = null, params object[] offenders)
        {
            return ClientClosedRequest(message, content, offenders);
        }

        public static Error InternalServerError(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.InternalServerError, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> InternalServerError<T>(string message, object content = null, params object[] offenders)
        {
            return InternalServerError(message, content, offenders);
        }

        public static Error NotImplemented(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.NotImplemented, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NotImplemented<T>(string message, object content = null, params object[] offenders)
        {
            return NotImplemented(message, content, offenders);
        }

        public static Error BadGateway(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.BadGateway, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> BadGateway<T>(string message, object content = null, params object[] offenders)
        {
            return BadGateway(message, content, offenders);
        }

        public static Error ServiceUnavailable(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.ServiceUnavailable, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> ServiceUnavailable<T>(string message, object content = null, params object[] offenders)
        {
            return ServiceUnavailable(message, content, offenders);
        }

        public static Error GatewayTimeout(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.GatewayTimeout, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> GatewayTimeout<T>(string message, object content = null, params object[] offenders)
        {
            return GatewayTimeout(message, content, offenders);
        }

        public static Error HttpVersionNotSupported(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 505, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> HttpVersionNotSupported<T>(string message, object content = null, params object[] offenders)
        {
            return HttpVersionNotSupported(message, content, offenders);
        }

        public static Error VariantAlsoNegotiates(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.VariantAlsoNegotiates, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> VariantAlsoNegotiates<T>(string message, object content = null, params object[] offenders)
        {
            return VariantAlsoNegotiates(message, content, offenders);
        }

        public static Error InsufficientStorage(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.InsufficientStorage, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> InsufficientStorage<T>(string message, object content = null, params object[] offenders)
        {
            return InsufficientStorage(message, content, offenders);
        }

        public static Error LoopDetected(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.LoopDetected, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> LoopDetected<T>(string message, object content = null, params object[] offenders)
        {
            return LoopDetected(message, content, offenders);
        }

        public static Error NotExtended(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.NotExtended, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NotExtended<T>(string message, object content = null, params object[] offenders)
        {
            return NotExtended(message, content, offenders);
        }

        public static Error NetworkAuthenticationRequired(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = (int)HttpStatusCode.NetworkAuthenticationRequired, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NetworkAuthenticationRequired<T>(string message, object content = null, params object[] offenders)
        {
            return NetworkAuthenticationRequired(message, content, offenders);
        }

        public static Error NetworkConnectTimeoutError(string message, object content = null, params object[] offenders)
        {
            return new Error() { StatusCode = 599, Message = message, Content = content, Offenders = offenders };
        }

        public static Safe<T> NetworkConnectTimeoutError<T>(string message, object content = null, params object[] offenders)
        {
            return NetworkConnectTimeoutError(message, content, offenders);
        }
    }
}