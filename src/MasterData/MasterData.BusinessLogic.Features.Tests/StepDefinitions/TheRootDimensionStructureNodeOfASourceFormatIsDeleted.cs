namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [When(@"the root DimensionStructureNode of a SourceFormat is deleted")]
        public async Task WhenTheRootDimensionStructureNodeOfASourceFormatIsDeleted(Table table)
        {
            KeyResultKeyEntity instance = table.CreateInstance<KeyResultKeyEntity>();

            SourceFormat input = ProvideInputForRootDimensionStructureNodeOfASourceFormat(
                instance.Key,
                _scenarioContext);

            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .RemoveRootDimensionStructureNodeAsync(input)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }

        private SourceFormat ProvideInputForRootDimensionStructureNodeOfASourceFormat(
            string selector,
            ScenarioContext context)
        {
            Check.NotNullOrEmptyOrWhitespace(selector);
            SourceFormat result = null;
            switch (selector)
            {
                case DeleteRootDimensionStructureNodeInputProviderSelectorsStruct.NULL:
                    break;

                case DeleteRootDimensionStructureNodeInputProviderSelectorsStruct.ZERO_ID:
                    SourceFormat sf = new();
                    result = sf;
                    break;

                default:
                    result = GetValueFromScenarioContext<SourceFormat>(selector, context);
                    break;
            }

            return result;
        }

        internal struct DeleteRootDimensionStructureNodeInputProviderSelectorsStruct
        {
            public const string NULL = "null";

            public const string ZERO_ID = "zero_id";
        }
    }
}
