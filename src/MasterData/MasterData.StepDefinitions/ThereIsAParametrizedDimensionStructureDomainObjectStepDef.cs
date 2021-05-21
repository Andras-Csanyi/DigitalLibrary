namespace DigitalLibrary.MasterData.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper.Helpers.ObjectPropertyValueHelper;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [SuppressMessage("ReSharper", "SA1600", Justification = "Justified")]
    [ExcludeFromCodeCoverage]
    [Binding]
    public class ThereIsAParametrizedDimensionStructureDomainObjectStepDef
    {
        private readonly ScenarioContext _scenarioContext;

        public ThereIsAParametrizedDimensionStructureDomainObjectStepDef(ScenarioContext _scenarioContext)
        {
            this._scenarioContext = _scenarioContext;
        }

        [Given(@"there is a parametrized DimensionStructure domain object")]
        public async Task ThereIsAParametrizedDimensionStructureDomainObject(Table table)
        {
            ThereIsAParametrizedDimensionStructureDomainObjectEntity instance = table
               .CreateInstance<ThereIsAParametrizedDimensionStructureDomainObjectEntity>();

            string Name = ObjectPropertyValueHelper.CreateStringValueForProperty(
                instance.Name,
                FilterRules.StringValueFilters);
            string Desc = ObjectPropertyValueHelper.CreateStringValueForProperty(
                instance.Desc,
                FilterRules.StringValueFilters);

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = Name,
                Desc = Desc,
                IsActive = int.Parse(instance.IsActive),
            };

            _scenarioContext.Add(instance.Key, dimensionStructure);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThereIsAParametrizedDimensionStructureDomainObjectEntity
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string IsActive { get; set; }
    }
}
