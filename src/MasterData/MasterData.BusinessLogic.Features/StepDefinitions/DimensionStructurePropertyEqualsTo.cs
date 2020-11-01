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
        [Then(@"DimensionStructure property equals to")]
        public void DimensionStructurePropertyEqualsTo(Table table)
        {
            Check.IsNotNull(table);
            DimensionStructurePropertyEqualsToEntity instance = table
               .CreateInstance<DimensionStructurePropertyEqualsToEntity>();

            DimensionStructure comparedTo = _scenarioContext[instance.ComparedToKey] as DimensionStructure;
            Check.IsNotNull(comparedTo);

            DimensionStructure result = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(result);

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.Name.Should().Be(comparedTo.Name);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.Desc.Should().Be(comparedTo.Desc);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    result.IsActive.Should().Be(comparedTo.IsActive);
                    break;

                default:
                    string msg = $"{instance.PropertyName} doesn't exist or not case covered.";
                    throw new MasterDataStepDefinitionException(msg);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    internal class DimensionStructurePropertyEqualsToEntity
    {
        public string Key { get; set; }

        public string PropertyName { get; set; }

        public string ComparedToKey { get; set; }
    }
}