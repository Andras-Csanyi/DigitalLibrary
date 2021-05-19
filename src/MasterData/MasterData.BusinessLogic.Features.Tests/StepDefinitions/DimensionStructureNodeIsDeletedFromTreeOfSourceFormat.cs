namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
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
        [When(@"DimensionStructureNode is deleted from tree of SourceFormat")]
        public async Task DimensionStructureNodeIsDeletedFromTreeOfSourceFormat(Table table)
        {
            DimensionStructureNodeIsDeletedFromTreeOfSourceFormatEntity instance =
                table.CreateInstance<DimensionStructureNodeIsDeletedFromTreeOfSourceFormatEntity>();

            DimensionStructureNode toBeDeleted = _scenarioContext[instance.DimensionStructureNodeKey]
                as DimensionStructureNode;
            Check.IsNotNull(toBeDeleted);
            DimensionStructureNode parent = _scenarioContext[instance.ParentDimensionStructureNodeKey]
                as DimensionStructureNode;
            Check.IsNotNull(parent);
            SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;
            Check.IsNotNull(sourceFormat);
            string operationResultKey = instance.OperationResultKey;
            Check.IsNotNull(operationResultKey);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteDimensionStructureNodeFromTreeAsync(
                        toBeDeleted.Id,
                        parent.Id,
                        sourceFormat.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(operationResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(operationResultKey, e);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructureNodeIsDeletedFromTreeOfSourceFormatEntity
    {
        public string DimensionStructureNodeKey { get; set; }

        public string ParentDimensionStructureNodeKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string OperationResultKey { get; set; }
    }
}
