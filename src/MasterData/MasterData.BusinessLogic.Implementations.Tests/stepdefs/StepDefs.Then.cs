namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.stepdefs
{
    using System;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefs
    {
        [Then(@"DimensionStructure property does not equal to")]
        public void DimensionStructurePropertyDoesNotEqualTo(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(
                string key,
                string propertyName,
                string notEqualTo)>();

            DimensionStructure result = _scenarioContext[instance.key] as DimensionStructure;

            switch (instance.propertyName)
            {
                case DimensionStructurePropertiesStruct.Id:
                    int notEqualToId = Convert.ToInt32(instance.notEqualTo);
                    result.Id.Should().NotBe(notEqualToId);
                    break;

                case DimensionStructurePropertiesStruct.Name:
                    result.Name.Should().NotBe(instance.notEqualTo);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.Desc.Should().NotBe(instance.notEqualTo);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    int notEqualToIsActive = Convert.ToInt32(instance.notEqualTo);
                    result.IsActive.Should().NotBe(notEqualToIsActive);
                    break;

                default:
                    string msg = $"{instance.propertyName} doesn't exist or not case covered.";
                    throw new MasterDataStepDefinitionException(msg);
            }
        }

        [Then(@"DimensionStructure property equals to")]
        public void DimensionStructurePropertyEqualsTo(Table table)
        {
            Check.IsNotNull(table);
            var instance = table.CreateInstance<(
                string key,
                string propertyName,
                string comparedToKey)>();
            DimensionStructure comparedTo = _scenarioContext[instance.comparedToKey] as DimensionStructure;
            DimensionStructure result = _scenarioContext[instance.key] as DimensionStructure;

            Check.IsNotNull(comparedTo);
            Check.IsNotNull(result);

            switch (instance.propertyName)
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
                    string msg = $"{instance.propertyName} doesn't exist or not case covered.";
                    throw new MasterDataStepDefinitionException(msg);
            }
        }

        [Then(@"DimensionStructure property is not null")]
        public void DimensionStructurePropertyIsNotNull(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(string key, string propertyName)>();

            DimensionStructure result = _scenarioContext[instance.key] as DimensionStructure;
            Check.IsNotNull(result);

            switch (instance.propertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.Name.Should().NotBeNull();
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.Desc.Should().NotBeNull();
                    break;

                default:
                    string msg = $"{instance.propertyName} doesn't exist or not case covered.";
                    throw new MasterDataStepDefinitionException(msg);
            }
        }

        [Then(@"SourceFormat result property equals to")]
        public void SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            DomainModel.SourceFormat comparedTo = _scenarioContext[instance.EqualsTo] as SourceFormat;

            switch (instance.PropertyName)
            {
                case SourceFormatPropertiesStruct.SourceFormatDimensionStructure:
                    // result.DimensionStructureTreeRoot.Should().NotBe(comparedTo.DimensionStructureTreeRoot);
                    break;

                case SourceFormatPropertiesStruct.Name:
                    result.Name.Should().Be(comparedTo.Name);
                    break;

                case SourceFormatPropertiesStruct.Desc:
                    result.Desc.Should().Be(comparedTo.Desc);
                    break;

                case SourceFormatPropertiesStruct.IsActive:
                    result.IsActive.Should().Be(comparedTo.IsActive);
                    break;

                default:
                    throw new Exception($"There is no {instance.PropertyName} property of SourceFormat.");
            }
        }

        [Then(@"'(.*)' SourceFormat result's RootDimensionStructure Id property is not zero")]
        public void SourceFormatResultsRootDimensionStructureIdIsNotZero(string resultKey)
        {
            DomainModel.SourceFormat result = _scenarioContext[resultKey] as SourceFormat;

            result.SourceFormatDimensionStructureNode.DimensionStructureNode.Id
               .Should()
               .NotBe(0);
        }

        [Then(@"SourceFormat result's RootDimensionStructure property equals to")]
        public void SourceFormatResultsRootDimensionStructurePropertyEqualsTo(Table table)
        {
            SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            DomainModel.DimensionStructure comparedTo = _scenarioContext[instance.EqualsTo] as DimensionStructure;

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.Name
                       .Should()
                       .Be(comparedTo.Name);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.Desc
                       .Should()
                       .Be(comparedTo.Desc);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.IsActive
                       .Should()
                       .Be(comparedTo.IsActive);
                    break;

                default:
                    throw new MasterDataStepDefinitionException(
                        nameof(SourceFormatResultsRootDimensionStructurePropertyEqualsTo));
            }
        }

        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public void SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            DomainModel.SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"'(.*)' SourceFormat save result is not null")]
        public void SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            DomainModel.SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Should().NotBeNull();
        }
    }
}