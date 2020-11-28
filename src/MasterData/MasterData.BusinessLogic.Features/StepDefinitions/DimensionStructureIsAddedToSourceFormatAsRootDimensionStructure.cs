namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is added to SourceFormat as root dimensionstructure")]
        [When(@"DimensionStructure is added to SourceFormat as root dimensionstructure")]
        public async Task DimensionStructureIsAddedToSourceFormatAsRootDimensionStructure(Table table)
        {
            DimensionStructureIsAddedToSourceFormatAsRootDimensionStructureEntity instance = table
               .CreateInstance<DimensionStructureIsAddedToSourceFormatAsRootDimensionStructureEntity>();

            if (string.IsNullOrEmpty(instance.SourceFormatKey)
             || string.IsNullOrWhiteSpace(instance.SourceFormatKey)
             || string.IsNullOrEmpty(instance.DimensionStructureKey)
             || string.IsNullOrWhiteSpace(instance.DimensionStructureKey))
            {
                string msg = $"Either {nameof(instance.SourceFormatKey)} or " +
                             $"{nameof(instance.DimensionStructureKey)} are null. Or both.";
                throw new Exception(msg);
            }

            DomainModel.SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            DomainModel.DimensionStructure dimensionStructure = _scenarioContext[instance.DimensionStructureKey]
                as DimensionStructure;

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureAsync(sourceFormat.Id, dimensionStructure.Id)
               .ConfigureAwait(false);

            DomainModel.SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithRootDimensionStructureAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Remove(instance.SourceFormatKey);
            _scenarioContext.Add(instance.SourceFormatKey, result);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructureIsAddedToSourceFormatAsRootDimensionStructureEntity
    {
        public string SourceFormatKey { get; set; }

        public string DimensionStructureKey { get; set; }
    }
}