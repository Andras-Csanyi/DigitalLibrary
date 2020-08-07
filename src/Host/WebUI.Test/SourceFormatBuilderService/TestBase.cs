namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
{
    using System.Diagnostics.CodeAnalysis;

    using MasterData.DomainModel;
    using MasterData.Validators;
    using MasterData.WebApi.Client;

    using Moq;

    using WebUi.Services;

    [ExcludeFromCodeCoverage]
    public class TestBase
    {
        protected Mock<IDomainEntityHelperService> _domainEntityHelperServiceMock =
            new Mock<IDomainEntityHelperService>();

        protected Mock<IMasterDataValidators> _masterDataValidatorsMock = new Mock<IMasterDataValidators>();

        protected Mock<IMasterDataHttpClient> _masterDataWebApiClientMock = new Mock<IMasterDataHttpClient>();

        protected SourceFormat _sourceFormat = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
            RootDimensionStructure = new DimensionStructure(),
            RootDimensionStructureId = 100,
        };

        protected SourceFormat _sourceFormatWithoutRootDimensionStructure = new SourceFormat
        {
            Id = 100,
            Name = "Test Source Format",
            Desc = "Test Source Format Description",
            IsActive = 1,
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