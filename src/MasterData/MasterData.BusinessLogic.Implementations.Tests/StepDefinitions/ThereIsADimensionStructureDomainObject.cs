namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.StepDefinitions
{
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Given(@"there is a DimensionStructure domain object")]
        public void ThereIsADimensionStructureDomainObject(Table table)
        {
            ThereIsADimensionStructureDomainObjectEntity instance = table
               .CreateInstance<ThereIsADimensionStructureDomainObjectEntity>();
            DomainModel.DimensionStructure dimensionStructure = _masterDataTestHelper
               .DimensionStructureFactory
               .Create(instance);

            if (string.IsNullOrEmpty(instance.Key) || string.IsNullOrWhiteSpace(instance.Key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _scenarioContext.Add(instance.Key, dimensionStructure);
        }
    }

    internal class ThereIsADimensionStructureDomainObjectEntity : IDimensionStructureDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}