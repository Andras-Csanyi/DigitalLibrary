namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"DimensionStructure property does not equal to")]
        public void DimensionStructurePropertyDoesNotEqualTo(Table table)
        {
            Check.IsNotNull(table);

            DimensionStructurePropertyDoesNotEqualToEntity instance = table
               .CreateInstance<DimensionStructurePropertyDoesNotEqualToEntity>();

            DimensionStructure result = _scenarioContext[instance.Key] as DimensionStructure;
            Check.IsNotNull(result);

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Id:
                    int notEqualToId = Convert.ToInt32(instance.NotEqualTo);
                    result.Id.Should().NotBe(notEqualToId);
                    break;

                case DimensionStructurePropertiesStruct.Name:
                    result.Name.Should().NotBe(instance.NotEqualTo);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.Desc.Should().NotBe(instance.NotEqualTo);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    int notEqualToIsActive = Convert.ToInt32(instance.NotEqualTo);
                    result.IsActive.Should().NotBe(notEqualToIsActive);
                    break;

                default:
                    string msg = $"{instance.PropertyName} doesn't exist or not case covered.";
                    throw new Exception(msg);
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class DimensionStructurePropertyDoesNotEqualToEntity
    {
        public string Key { get; set; }

        public string PropertyName { get; set; }

        public string NotEqualTo { get; set; }
    }
}