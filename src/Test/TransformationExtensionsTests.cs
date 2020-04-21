using FluentAssertions;
using System;
using System.Threading.Tasks;
using SafeT;
using SafeT.Transforms;
using Xunit;

namespace Test
{
    public class TransformationExtensionsTests
    {
        [Fact]
        public void ToSafe()
        {
            // Arrange

            int me = 12;

            // Act
            var result = me.ToSafe();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(me);
        }

        [Fact]
        public void Transform_Success()
        {
            // Arrange

            Safe<int> from = 12;

            // Act
            var result = from.Transform(o=>o + 5);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(17);
        }

        [Fact]
        public void Transform_DivideByZero()
        {
            // Arrange

            Safe<int> from = 12;

            // Act
            var result = from.Transform(o => o/0);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.StatusCode.Should().Be(500);
            result.AsError.Message.Should().Be("Attempted to divide by zero.");
        }

        [Fact]
        public async Task TransformAsync_AsyncFrom()
        {
            // Arrange

            Task<Safe<int>> from = Task.FromResult(Safe<int>.Ok(12));
            Func<int,int> func = o => o + 5;

            // Act
            var result = await from.TransformAsync(func);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(17);
        }

        [Fact]
        public async Task TransformAsync_AsyncFunc()
        {
            // Arrange

            Safe<int> from = 12;
            Func<int, Task<int>> func = async o => await Task.FromResult(o + 5);

            // Act
            var result = await from.TransformAsync(func);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(17);
        }

        [Fact]
        public async Task TransformAsync_AsyncFunc_Task()
        {
            // Arrange

            Task<Safe<int>> from = Task.FromResult(Safe<int>.Ok(12));
            Func<int, Task<int>> func = async o => await Task.FromResult(o + 5);

            // Act
            var result = await from.TransformAsync(func);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(17);
        }
    }
}
