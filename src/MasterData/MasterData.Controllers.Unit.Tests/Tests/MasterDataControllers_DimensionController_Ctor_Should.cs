using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using FluentAssertions;

using Xunit;

namespace DigitalLibrary.MasterData.Controllers.Unit.Tests.Tests
{
    [ExcludeFromCodeCoverage]
    public class MasterDataControllers_DimensionController_Ctor_Should
    {
        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new DimensionController(null); };

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}