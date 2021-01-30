namespace DigitalLibrary.MasterData.Web.Api.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper.Entities;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"stored DimensionStructure object properties are set to")]
        public void GivenStoredDimensionStructureObjectPropertiesAreSetTo(Table table)
        {
            GivenStoredDimensionStructureObjectPropertiesAreSetToEntity instance = table
               .CreateInstance<GivenStoredDimensionStructureObjectPropertiesAreSetToEntity>();

            DimensionStructure target = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(target);

            target.Name = instance.Name;
            target.Desc = instance.Desc;
            target.IsActive = instance.IsActive;

            _scenarioContext.Remove(instance.ResultKey);
            _scenarioContext.Add(instance.ResultKey, target);
        }
    }

    [ExcludeFromCodeCoverage]
    internal class GivenStoredDimensionStructureObjectPropertiesAreSetToEntity : KeyResultKeyEntity
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }
    }
}