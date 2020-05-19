using SafeT;
using System;
using FluentAssertions;
using Xunit;

namespace Test
{
    public class SafeTests
    {
        [Fact]
        public void Ok_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var item = 12;

            // Act
            var result = Safe<int>.Ok(item);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.AsSuccess.Should().Be(12);
        }

        [Fact]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Error item = new Error() { Message = "ABC", Content = "DEF", StatusCode = 101 };

            // Act
            var result = Safe<int>.Error(item);

            // Assert
            result.IsError.Should().BeTrue();
            result.AsError.Message.Should().Be("ABC");
            result.AsError.Content.Should().Be("DEF");
            result.AsError.StatusCode.Should().Be(101);
        }

        [Fact]
        public void AsError_BadCall()
        {
            // Arrange
            var item = 12;

            // Act
            var result = Safe<int>.Ok(item);

            var r = new Func<Error>(() => result.AsError);


            // Assert
            r.Should().Throw<SafeException<int>>();


        }

        [Fact]
        public void AsSuccess_BadCall()
        {
            // Arrange
            Error item = new Error() { Message = "ABC", Content = "DEF", StatusCode = 101 };

            // Act
            var result = Safe<int>.Error(item);

            var r = new Func<int>(() => result.AsSuccess);


            // Assert
            r.Should().Throw<SafeException<int>>();
        }
    }
}
