using Safe.Http;
using Safe;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Test
{
    public class ActionResultExtensionsTests
    {
        [Fact]
        public void ToIActionResult_Success()
        {
            // Arrange
            Safe<int> me = 12;

            // Act
            var result = me.ToIActionResult();

            // Assert
            var res = result.Should().BeAssignableTo<OkObjectResult>().Subject;
            res.Value.Should().Be(12);
        }

        [Fact] public void ToIActionResult_Failure()
        {
            // Arrange
            var error = new Error() { Message = "abc", StatusCode = 401, Content = 18 };
            Safe<int> me = error;

            // Act
            var result = me.ToIActionResult();

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.StatusCode.Should().Be(401);
            res.Value.Should().Be(error);
        }

        [Fact]
        public void ToIActionResult_Success2()
        {
            // Arrange
            Safe<int> me = 12;
            HttpStatusCode successStatusCode = HttpStatusCode.Created;

            // Act
            var result = me.ToIActionResult(successStatusCode);

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.StatusCode.Should().Be((int) HttpStatusCode.Created);
            res.Value.Should().Be(12);
        }

        [Fact]
        public void ToIActionResult_Failure2()
        {
            // Arrange
            var error = new Error() { Message = "abc", StatusCode = 401, Content = 18 };
            Safe<int> me = error;
            HttpStatusCode successStatusCode = HttpStatusCode.Created;

            // Act
            var result = me.ToIActionResult(successStatusCode);

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.StatusCode.Should().Be(401);
            res.Value.Should().Be(error);
        }

        [Fact]
        public async Task ToIActionResultAsync_Success()
        {
            // Arrange
            Task<Safe<int>> me = Task.FromResult(Safe<int>.Ok(12));

            // Act
            var result = await me.ToIActionResultAsync();

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.Value.Should().Be(12);
        }

        [Fact] public async Task ToIActionResultAsync_Fail()
        {
            // Arrange
            var error = new Error() { Message = "abc", StatusCode = 401, Content = 18 };

            Task<Safe<int>> me = Task.FromResult(Safe<int>.Error(error)); 
            // Act
            var result = await me.ToIActionResultAsync();

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.StatusCode.Should().Be(401);
            res.Value.Should().Be(error);
        }

        [Fact]
        public async Task ToIActionResultAsync_Success2()
        {
            // Arrange
            var error = new Error() { Message = "abc", StatusCode = 401, Content = 18 };
            Task<Safe<int>> me = Task.FromResult(Safe<int>.Error(error));
            HttpStatusCode successStatusCode = HttpStatusCode.Created;

            // Act
            var result = await me.ToIActionResultAsync(successStatusCode);

            // Assert
            var res = result.Should().BeAssignableTo<ObjectResult>().Subject;
            res.StatusCode.Should().Be(401);
            res.Value.Should().Be(error);
        }
    }
}
