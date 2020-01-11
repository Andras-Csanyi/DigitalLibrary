namespace DigitalLibrary.IaC.MasterData.Controllers.Unit.Tests.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Controllers;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class MasterDataControllers_DimensionStructure_Ctor_Should
    {
        [Fact]
        public void ThrowException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { new TopDimensionStructureController(null); };

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}