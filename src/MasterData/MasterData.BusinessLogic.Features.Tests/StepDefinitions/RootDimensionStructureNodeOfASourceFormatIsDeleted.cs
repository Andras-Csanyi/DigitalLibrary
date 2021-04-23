namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"RootDimensionStructureNode of a SourceFormat is deleted")]
        public async Task RootDimensionStructureNodeOfASourceFormatIsDeleted(Table table)
        {
            RootDimensionStructureNodeOfASourceFormatIsDeletedEntity instance = table
               .CreateInstance<RootDimensionStructureNodeOfASourceFormatIsDeletedEntity>();

            DimensionStructureNode rootDimensionStructureNode = _scenarioContext[instance.RootDimensionStructureNodeKey]
                as DimensionStructureNode;
            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteRootDimensionStructureNodeAsync(
                        rootDimensionStructureNode.Id,
                        sourceFormat.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.OperationResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.OperationResultKey, e);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class RootDimensionStructureNodeOfASourceFormatIsDeletedEntity
    {
        public String RootDimensionStructureNodeKey { get; set; }

        public String SourceFormatKey { get; set; }

        public String OperationResultKey { get; set; }
    }
}