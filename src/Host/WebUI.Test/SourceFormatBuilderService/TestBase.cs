namespace WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Moq;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();

        protected SourceFormat _sourceFormatWithoutRootDimensionStructure = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
        };

        protected SourceFormat _sourceFormat = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure(),
            RootDimensionStructureId = 100,
        };
    }
}