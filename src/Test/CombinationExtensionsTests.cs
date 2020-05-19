using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SafeT;
using Xunit;

namespace Test
{
    public class CombinationExtensionsTests
    {
        [Fact]
        public void Combine_Success()
        {
            // Arrange
            IEnumerable<Safe<int>> items = new[] { Safe<int>.Ok( 12 ), Safe<int>.Ok(17) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.Combine(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Count().Should().Be(2);
        }

        [Fact]
        public void Combine_Failure()
        {
            // Arrange
            IEnumerable<Safe<int>> items = new[] { Safe<int>.Error(new Error(){ Message = "abc", Content = 52, StatusCode = 400, Offenders = new object[]{ 49 }}), Safe<int>.Ok(17) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.Combine(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(400);
        }
        [Fact]
        public void Combine_Failure2()
        {
            // Arrange
            IEnumerable<Safe<int>> items = new[] { Safe<int>.Error(new Error() { Message = "abc", Content = 52, StatusCode = 400, Offenders = new object[] { 49 } }), Safe<int>.Error(new Error() { Message = "abc", Content = 52, StatusCode = 401, Offenders = new object[] { 49 } }) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.Combine(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(0);
        }

        [Fact]
        public void CombineMany_Success()
        {
            // Arrange
            IEnumerable<Safe<IEnumerable<int>>> items = new [] { Safe<IEnumerable<int>>.Ok(new []{ 12 }), Safe<IEnumerable<int>>.Ok(new[] { 17 }) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.CombineMany(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Count().Should().Be(2);
        }

       
        [Fact]
        public void CombineMany_Failure()
        {
            // Arrange
            IEnumerable<Safe<IEnumerable<int>>> items = new[] { Safe<IEnumerable<int>>.Error(new Error() { Message = "abc", Content = 52, StatusCode = 400, Offenders = new object[] { 49 } }), Safe<IEnumerable<int>>.Ok(new[] { 17 }) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.CombineMany(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(400);
        }

        [Fact]
        public void CombineMany_Failure2()
        {
            // Arrange
            IEnumerable<Safe<IEnumerable<int>>> items = new[] { Safe<IEnumerable<int>>.Error(new Error() { Message = "abc", Content = 52, StatusCode = 400, Offenders = new object[] { 49 } }), Safe<IEnumerable<int>>.Error(new Error() { Message = "abc", Content = 52, StatusCode = 401, Offenders = new object[] { 49 } }) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = items.CombineMany(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(defaultStatusCode);
        }

        [Fact]
        public async Task CombineAsync_Success()
        {
            // Arrange
            IEnumerable<Task<Safe<int>>> items = new [] { Task.FromResult(Safe<int>.Ok(12)), Task.FromResult(Safe<int>.Ok(17)) };
            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = await items.CombineAsync(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Count().Should().Be(2);
        }

        [Fact]
        public async Task CombineManyAsync_Success()
        {
            // Arrange
            IEnumerable<Task<Safe<IEnumerable<int>>>> items = new[] { Task.FromResult(Safe<IEnumerable<int>>.Ok( new []{ 12, 17 })) };

            string defaultMessage = null;
            int defaultStatusCode = 0;

            // Act
            var result = await items.CombineManyAsync(
                defaultMessage,
                defaultStatusCode);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Count().Should().Be(2);
        }
    }
}
