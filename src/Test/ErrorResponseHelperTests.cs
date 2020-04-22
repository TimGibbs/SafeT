using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using static SafeT.Http.ErrorResponseHelper;

namespace Test
{
    public class ErrorResponseHelperTests
    {
        [Fact]
        public void BadRequest_Error()
        {
            // Arrange

            string message = "This is a list of int";
            object content = new List<int>() { 1, 2, 3, 4, 5 };
            object[] offenders = { message, content };

            // Act
            var result = BadRequest(
                message,
                content,
                offenders);

            // Assert
            result.StatusCode.Should().Be(400);
            result.Message.Should().Be(message);
            result.Content.Should().Be(content);
            result.Offenders.Should().Contain(message);
            result.Offenders.Should().Contain(content);
        }

        [Fact]
        public void BadRequest_Safe()
        {
            // Arrange

            string message = "This is a list of int";
            object content = new List<int>() { 1, 2, 3, 4, 5 };
            object[] offenders = { message, content };

            // Act
            var result = BadRequest<int>(
                message,
                content,
                offenders);

            // Assert
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(400);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void Unauthorized_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = Unauthorized<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(401);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void PaymentRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = PaymentRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(402);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void Forbidden_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = Forbidden<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(403);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NotFound_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NotFound<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(404);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void MethodNotAllowed_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = MethodNotAllowed<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(405);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NotAcceptable_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NotAcceptable<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(406);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ProxyAuthenticationRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ProxyAuthenticationRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(407);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void RequestTimeout_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = RequestTimeout<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(408);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void Conflict_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = Conflict<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(409);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void Gone_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = Gone<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(410);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void LengthRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = LengthRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(411);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void PreconditionFailed_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = PreconditionFailed<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(412);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void PayloadTooLarge_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = PayloadTooLarge<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(413);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void RequestUriTooLong_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = RequestUriTooLong<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(414);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void UnsupportedMediaType_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = UnsupportedMediaType<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(415);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void RequestedRangeNotSatisfiable()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};

            var result = RequestedRangeNotSatisfiable<int>(message, content, offenders);

            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(416);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ExpectationFailed_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ExpectationFailed<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(417);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ImATeapot_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ImATeapot<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(418);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void MisdirectedRequest_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = MisdirectedRequest<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(421);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void UnprocessableEntity_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = UnprocessableEntity<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(422);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void Locked_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = Locked<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(423);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void FailedDependency_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = FailedDependency<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(424);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void TooEarly_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = TooEarly<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(425);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void UpgradeRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = UpgradeRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(426);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void PreconditionRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = PreconditionRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(428);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void TooManyRequests_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = TooManyRequests<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(429);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void RequestHeaderFieldsTooLarge_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = RequestHeaderFieldsTooLarge<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(431);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ConnectionClosedWithoutResponse_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ConnectionClosedWithoutResponse<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(444);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void UnavailableForLegalReasons_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = UnavailableForLegalReasons<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(451);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ClientClosedRequest_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ClientClosedRequest<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(499);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void InternalServerError_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = InternalServerError<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(500);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NotImplemented_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NotImplemented<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(501);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void BadGateway_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = BadGateway<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(502);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void ServiceUnavailable_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = ServiceUnavailable<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(503);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void GatewayTimeout_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = GatewayTimeout<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(504);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void HttpVersionNotSupported_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = HttpVersionNotSupported<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(505);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void VariantAlsoNegotiates_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = VariantAlsoNegotiates<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(506);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void InsufficientStorage_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = InsufficientStorage<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(507);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void LoopDetected_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = LoopDetected<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(508);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NotExtended_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NotExtended<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(510);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NetworkAuthenticationRequired_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NetworkAuthenticationRequired<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(511);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }

        [Fact]
        public void NetworkConnectTimeoutError_Safe()
        {
            string message = "This is a list of int";
            object content = new List<int>() {1, 2, 3, 4, 5};
            object[] offenders = {message, content};
            var result = NetworkConnectTimeoutError<int>(message, content, offenders);
            result.IsError.Should().BeTrue();
            var r = result.AsError;
            r.StatusCode.Should().Be(599);
            r.Message.Should().Be(message);
            r.Content.Should().Be(content);
            r.Offenders.Should().Contain(message);
            r.Offenders.Should().Contain(content);
        }
    }
}