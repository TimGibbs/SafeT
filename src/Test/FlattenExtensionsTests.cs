using System.Threading.Tasks;
using FluentAssertions;
using SafeT;
using Xunit;

namespace Test
{
    public class FlattenExtensionsTests
    {
        [Fact]
        public void Flatten_Success()
        {
            // Arrange
            Safe<Safe<int>> me = Safe<Safe<int>>.Ok(12);

            // Act
            var result = me.Flatten();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(12);
        }

        [Fact]
        public void Flatten_Fail1()
        {
            // Arrange
            Safe<Safe<int>> me = Safe<Safe<int>>.Error(new Error() { Message="abc", StatusCode = 12});

            // Act
            var result = me.Flatten();

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(12);
        }
        [Fact]
        public void Flatten_Fail2()
        {
            // Arrange
            Safe<Safe<int>> me = Safe<Safe<int>>.Ok(Safe<int>.Error(new Error() { Message = "abc", StatusCode = 12 }));

            // Act
            var result = me.Flatten();

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(12);
        }

        [Fact]
        public async Task FlattenAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Task<Safe<Safe<int>>> me = Task.FromResult(Safe<Safe<int>>.Ok(12));

            // Act
            var result = await me.FlattenAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(12);
        }

        [Fact]
        public async Task FlattenAsync_Success()
        {
            // Arrange
            Safe<Task<Safe<int>>> me = Safe<Task<Safe<int>>>.Ok(Task.FromResult(Safe<int>.Ok(12)));

            // Act
            var result = await me.FlattenAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(12);
        }

        [Fact]
        public async Task FlattenAsync_Fail1()
        {
            // Arrange
            Safe<Task<Safe<int>>> me = Safe<Task<Safe<int>>>.Error(new Error() { Message = "abc", StatusCode = 12 });

            // Act
            var result = await me.FlattenAsync();

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(12);
        }

        [Fact]
        public async Task FlattenAsync_Fail2()
        {
            // Arrange
            Safe<Task<Safe<int>>> me = Safe<Task<Safe<int>>>.Ok(Task.FromResult(Safe<int>.Error(new Error() { Message = "abc", StatusCode = 12 })));

            // Act
            var result = await me.FlattenAsync();

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("abc");
            result.AsError.StatusCode.Should().Be(12);
        }
    }
}
