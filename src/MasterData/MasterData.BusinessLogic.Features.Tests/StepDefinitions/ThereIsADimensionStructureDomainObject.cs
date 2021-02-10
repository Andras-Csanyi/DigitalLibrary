namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

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

            _scenarioContext.Add(instance.Key, dimensionStructure);
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class ThereIsADimensionStructureDomainObjectEntity : IDimensionStructureDomainObject
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }
    }
}