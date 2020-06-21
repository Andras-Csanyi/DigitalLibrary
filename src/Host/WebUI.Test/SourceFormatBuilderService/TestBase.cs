namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.MasterData.WebApi.Client;

    using Moq;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();

        protected Mock<IMasterDataValidators> _masterDataValidatorsMock = new Mock<IMasterDataValidators>();

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

        protected MasterDataValidators GetMasterDataValidators()
        {
            DimensionValidator dimensionValidator = new DimensionValidator();
            MasterDataDimensionValueValidator masterDataDimensionValueValidator =
                new MasterDataDimensionValueValidator();
            SourceFormatValidator sourceFormatValidator = new SourceFormatValidator();
            DimensionStructureValidator dimensionStructureValidator = new DimensionStructureValidator();
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator =
                new DimensionStructureDimensionStructureValidator();
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator =
                new DimensionStructureQueryObjectValidator();

            MasterDataValidators validators = new MasterDataValidators(
                dimensionValidator,
                masterDataDimensionValueValidator,
                sourceFormatValidator,
                dimensionStructureValidator,
                dimensionStructureDimensionStructureValidator,
                dimensionStructureQueryObjectValidator
            );
            return validators;
        }
    }
}