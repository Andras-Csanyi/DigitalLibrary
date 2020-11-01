namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"DimensionStructure is deleted from the tree")]
        public async Task DimensionStructureIsDeletedFromTheTree(Table table)
        {
            DimensionStructureIsDeletedFromTheTreeEntity instance = table
               .CreateInstance<DimensionStructureIsDeletedFromTheTreeEntity>();

            DimensionStructure toBeDeleted = _scenarioContext[instance.DimensionStructureKey] as DimensionStructure;
            Check.IsNotNull(toBeDeleted);

            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);

            try
            {
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteFromTree(toBeDeleted.Id, sourceFormat.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class DimensionStructureIsDeletedFromTheTreeEntity
    {
        public string DimensionStructureKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string ResultKey { get; set; }
    }
}