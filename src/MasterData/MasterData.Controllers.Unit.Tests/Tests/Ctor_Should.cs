namespace DigitalLibrary.MasterData.Controllers.Unit.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Utils.Guards;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class Ctor_Should
    {
        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new SourceFormatController(null); };

            // Assert
            action.Should().ThrowExactly<GuardException>();
        }
    }
}