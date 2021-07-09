namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;

    using DiLibHttpClientResponseObjects;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"DimensionStructureNode is added to SourceFormat as root DimensionStructureNode")]
        public async Task DimensionStructureNodeIsAddedToSourceFormatAsRootDimensionStructureNode(Table table)
        {
            DimensionStructureNodeIsAddedToSourceFormatAsRootDimensionStructureNodeEntity instance = table
               .CreateInstance<DimensionStructureNodeIsAddedToSourceFormatAsRootDimensionStructureNodeEntity>();

            bool doesSourceFormatExist = GetKeyValueFromScenarioContext<bool>(ScenarioContextKeys.SourceFormatExist);
            bool doesDimensionStructureNodeExist =
                GetKeyValueFromScenarioContext<bool>(ScenarioContextKeys.DimensionStructureNodeIdExist);
            long sourceFormatIdFromContext = GetKeyValueFromScenarioContext<long>(ScenarioContextKeys.SourceFormatId);
            long dimensionStructureNodeIdFromContext =
                GetKeyValueFromScenarioContext<long>(ScenarioContextKeys.DimensionStructureNodeId);

            long dimensionStructureNodeId = 0;
            long sourceFormatId = 0;

            if (doesSourceFormatExist)
            {
                SourceFormat sourceFormat = await CreateSourceFormatEntity().ConfigureAwait(false);
                sourceFormatId = sourceFormat.Id;
            }
            else
            {
                sourceFormatId = sourceFormatIdFromContext;
            }

            if (doesDimensionStructureNodeExist)
            {
                DimensionStructureNode node = await CreateDimensionStructureNodeEntity().ConfigureAwait(false);
                dimensionStructureNodeId = node.Id;
            }
            else
            {
                dimensionStructureNodeId = dimensionStructureNodeIdFromContext;
            }

            AddRootDimensionStructureNodeViewModel addRootDimensionStructureNodeViewModel =
                new AddRootDimensionStructureNodeViewModel
                {
                    SourceFormatId = sourceFormatId,
                    DimensionStructureNodeId = dimensionStructureNodeId,
                };

            DilibHttpClientResponse<SourceFormat> result = await _masterDataHttpClient
               .SourceFormatHttpClient
               .AddRootDimensionStructureNodeAsync(addRootDimensionStructureNodeViewModel)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.ResultKey, result);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class DimensionStructureNodeIsAddedToSourceFormatAsRootDimensionStructureNodeEntity
    {
        public string ResultKey { get; set; }
    }
}
