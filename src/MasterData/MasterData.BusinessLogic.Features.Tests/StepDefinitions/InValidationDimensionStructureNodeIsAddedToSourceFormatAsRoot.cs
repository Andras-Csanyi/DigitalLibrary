namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"in validation DimensionStructureNode is added to SourceFormat as root")]
        public async Task InValidationDimensionStructureNodeIsAddedToSourceFormatAsRoot(Table table)
        {
            InValidationDimensionStructureNodeIsAddedToSourceFormatAsRoot instance = table
               .CreateInstance<InValidationDimensionStructureNodeIsAddedToSourceFormatAsRoot>();

            string dimensionStructureNodeId = instance.DimensionStructureNodeIdKey;
            long dimensionStructureNodeIdFinal;

            bool isDimensionStructureNodeIdNumber = dimensionStructureNodeId.ToCharArray().All(char.IsDigit);
            if (isDimensionStructureNodeIdNumber == false)
            {
                DimensionStructureNode dimensionStructureNode = _scenarioContext[instance.DimensionStructureNodeIdKey]
                    as DimensionStructureNode;
                Check.IsNotNull(dimensionStructureNode);
                dimensionStructureNodeIdFinal = dimensionStructureNode.Id;
            }
            else
            {
                dimensionStructureNodeIdFinal = Convert.ToInt64(dimensionStructureNodeId);
            }

            string sourceFormatId = instance.SourceFormatIdKey;
            long sourceFormatIdFinal;

            bool isSourceFormatIdNumber = sourceFormatId.ToCharArray().All(char.IsDigit);
            if (isSourceFormatIdNumber == false)
            {
                SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatIdKey] as SourceFormat;
                Check.IsNotNull(sourceFormat);
                sourceFormatIdFinal = sourceFormat.Id;
            }
            else
            {
                sourceFormatIdFinal = Convert.ToInt64(sourceFormatId);
            }

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddRootDimensionStructureNodeAsync(sourceFormatIdFinal, dimensionStructureNodeIdFinal)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }
    }

    internal class InValidationDimensionStructureNodeIsAddedToSourceFormatAsRoot
    {
        public string DimensionStructureNodeIdKey { get; set; }

        public string ResultKey { get; set; }

        public string SourceFormatIdKey { get; set; }
    }
}