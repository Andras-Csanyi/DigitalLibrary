namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using MasterData.DomainModel;

    using Moq;

    using WebUi.Components.SourceFormatBuilder;

    using Xunit;

    public class AddOrUpdateDocumentStructureToTreeAsync_Add_Should : TestBase
    {
        /// <summary>
        ///     Until this:
        ///     https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        ///     is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_FirstLevel_ListHasMultipleItems()
        {
        }

        /// <summary>
        ///     Until this:
        ///     https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        ///     is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_EmptyList()
        {
        }

        /// <summary>
        ///     Until this:
        ///     https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        ///     is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_SecondLevel_LastHasMultipleItems()
        {
        }

        /// <summary>
        ///     Until this:
        ///     https://stackoverflow.com/questions/60441646/how-to-setup-moq-for-the-same-method-where-return-value-depends-on-input
        ///     is not solved this part of the testing is suspended
        /// </summary>
        /// <returns></returns>
        public async Task AddItemTo_WhenAnItemIsAdded()
        {
        }

        [Fact]
        public async Task AddItem_ToEmpty_RootDimensionStructure()
        {
            // Arrange
            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure newOne = new DimensionStructure
            {
                Name = "something new",
                Desc = "description",
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddOrUpdateDocumentStructureToTreeAsync(
                    newOne,
                    _sourceFormat.RootDimensionStructure.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should()
               .Be(1);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0)
               .Name.Should().Be(newOne.Name);

            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .ElementAt(0)
               .Desc.Should().Be(newOne.Desc);
        }

        [Fact]
        public async Task AddItemTo_FirstLevel_EmptyLengthList()
        {
            // Arrange
            DimensionStructure firstOne = new DimensionStructure
            {
                Name = "first one",
                Desc = "second one"
            };
            _sourceFormat.RootDimensionStructure.ChildDimensionStructures.Add(firstOne);

            _masterDataWebApiClientMock
               .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
               .ReturnsAsync(_sourceFormat);

            ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
                _masterDataWebApiClientMock.Object,
                _masterDataValidatorsMock.Object,
                _domainEntityHelperServiceMock.Object);

            DimensionStructure newOne = new DimensionStructure
            {
                Name = "something new",
                Desc = "description",
            };
            await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);

            // Act
            await sourceFormatBuilderService.AddOrUpdateDocumentStructureToTreeAsync(
                    newOne,
                    _sourceFormat.RootDimensionStructure.Guid)
               .ConfigureAwait(false);

            // Assert
            sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .Count
               .Should()
               .Be(2);

            DimensionStructure res = sourceFormatBuilderService.SourceFormat.RootDimensionStructure
               .ChildDimensionStructures
               .FirstOrDefault(p => p.Guid == newOne.Guid);
            res.Should().NotBeNull();
            // ReSharper disable once PossibleNullReferenceException
            res.Name.Should().Be(newOne.Name);
            res.Desc.Should().Be(newOne.Desc);
        }
    }
}