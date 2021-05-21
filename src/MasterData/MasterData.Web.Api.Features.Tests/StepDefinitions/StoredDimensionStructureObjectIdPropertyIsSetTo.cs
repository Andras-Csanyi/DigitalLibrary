namespace DigitalLibrary.MasterData.Web.Api.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored DimensionStructure object Id property is set to")]
        public void GivenStoredDimensionStructureObjectIdPropertyIsSetTo(Table table)
        {
            GivenStoredDimensionStructureObjectIdPropertyIsSetTo instance = table
               .CreateInstance<GivenStoredDimensionStructureObjectIdPropertyIsSetTo>();

            DimensionStructure stored = _scenarioContext[instance.Key] as DimensionStructure;

            stored.Id = instance.IdValue;

            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, stored);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class GivenStoredDimensionStructureObjectIdPropertyIsSetTo : KeyResultKeyEntity
    {
        public long IdValue { get; set; }
    }
}
