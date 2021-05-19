namespace DigitalLibarary.MasterData.DomainModel.Unit.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class SourceFormatDimensionStructureNode_Should
    {
        [Fact]
        public void Have_Zero_AsDefaultValueFor_Id()
        {
            // Arrange
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode();

            // Assert
            sut.Id.Should().Be(0);
        }

        [Fact]
        public void Have_Null_AsDefaultValue_For_DimensionStructureNode()
        {
            // Arrange
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode();

            // Assert
            sut.DimensionStructureNode.Should().BeNull();
        }

        [Fact]
        public void Have_Null_AsDefaultValue_For_DimensionStructureNodeId()
        {
            // Arrange
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode();

            // Assert
            sut.DimensionStructureNodeId.Should().BeNull();
        }

        [Fact]
        public void Have_Null_AsDefaultValue_For_SourceFormat()
        {
            // Arrange
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode();

            // Assert
            sut.SourceFormat.Should().BeNull();
        }

        [Fact]
        public void Have_Null_AsDefaultValue_For_SourceFormatId()
        {
            // Arrange
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode();

            // Assert
            sut.SourceFormatId.Should().BeNull();
        }

        [Fact]
        public async Task Id_NotChange_DuringSetGet()
        {
            // Arrange
            long Id = 100;

            // Act
            SourceFormatDimensionStructureNode sut = new SourceFormatDimensionStructureNode
            {
                Id = Id,
            };

            // Assert
            sut.Id.Should().Be(Id);
        }
    }
}
