namespace DigitalLibrary.MasterData.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using Bogus;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [SuppressMessage("ReSharper", "SA1600", Justification = "Justified")]
    [ExcludeFromCodeCoverage]
    [Binding]
    public class ThereIsADimensionStructureDomainObjectStepDef
    {
        private readonly ScenarioContext _scenarioContext;

        public ThereIsADimensionStructureDomainObjectStepDef(
            ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"there is a DimensionStructure domain object")]
        public void ThereIsADimensionStructureDomainObject(Table table)
        {
            ThereIsADimensionStructureDomainObjectStepDefEntity instance = table
               .CreateInstance<ThereIsADimensionStructureDomainObjectStepDefEntity>();
            Check.NotNullOrEmptyOrWhitespace(instance.Key);

            DimensionStructure dimensionStructure = new Faker<DimensionStructure>()
               .RuleFor(u => u.Name, f => f.Company.CompanyName(1))
               .RuleFor(u => u.Desc, u => $"{u.Name} description.")
               .RuleFor(u => u.IsActive, f => f.IndexFaker)
               .Generate();

            _scenarioContext.Add(instance.Key, dimensionStructure);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThereIsADimensionStructureDomainObjectStepDefEntity
    {
        public string Key { get; set; }
    }
}
