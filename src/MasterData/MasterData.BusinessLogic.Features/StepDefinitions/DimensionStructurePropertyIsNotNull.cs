namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure property is not null")]
        public void DimensionStructurePropertyIsNotNull(Table table)
        {
            Check.IsNotNull(table);

            DimensionStructurePropertyIsNotNullEntity instance = table
               .CreateInstance<DimensionStructurePropertyIsNotNullEntity>();

            DimensionStructure result = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(result);

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.Name.Should().NotBeNull();
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.Desc.Should().NotBeNull();
                    break;

                default:
                    string msg = $"{instance.PropertyName} doesn't exist or not case covered.";
                    throw new MasterDataStepDefinitionException(msg);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructurePropertyIsNotNullEntity
    {
        public string Key { get; set; }

        public string PropertyName { get; set; }
    }
}