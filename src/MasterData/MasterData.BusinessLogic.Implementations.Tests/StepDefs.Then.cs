namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    public partial class StepDefs
    {
        [Then(@"'(.*)' SourceFormat save result is not null")]
        public async Task SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            DomainModel.SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Should().NotBeNull();
        }

        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public async Task SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            DomainModel.SourceFormat result = _scenarioContext[saveResultName] as SourceFormat;
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"SourceFormat result property equals to")]
        public async Task SourceFormatResultPropertyEqualsTo(Table table)
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

        [Then(@"SourceFormat result property is not null")]
        public async Task SourceFormatResultPropertyIsNotNull(Table table)
        {
            SourceFormatPropertyIsNotNullEntity instance = table.CreateInstance<SourceFormatPropertyIsNotNullEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Name] as SourceFormat;

            switch (instance.PropertyName)
            {
                case SourceFormatPropertiesStruct.SourceFormatDimensionStructure:
                    // result.DimensionStructureTreeRoot.Should().NotBeNull();
                    break;

                default:
                    throw new Exception($"There is no {instance.PropertyName} property of SourceFormat.");
            }
        }

        [Then(@"SourceFormat result's RootDimensionStructure property equals to")]
        public async Task SourceFormatResultsRootDimensionStructurePropertyEqualsTo(Table table)
        {
            SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            DomainModel.DimensionStructure comparedTo = _scenarioContext[instance.EqualsTo] as DimensionStructure;

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.SourceFormatDimensionStructure.DimensionStructure.Name
                       .Should()
                       .Be(comparedTo.Name);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.SourceFormatDimensionStructure.DimensionStructure.Desc
                       .Should()
                       .Be(comparedTo.Desc);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    result.SourceFormatDimensionStructure.DimensionStructure.IsActive
                       .Should()
                       .Be(comparedTo.IsActive);
                    break;

                default:
                    throw new MasterDataStepDefinitionException(
                        nameof(SourceFormatResultsRootDimensionStructurePropertyEqualsTo));
            }
        }

        [Then(@"'(.*)' SourceFormat result's RootDimensionStructure Id property is not zero")]
        public async Task SourceFormatResultsRootDimensionStructureIdIsNotZero(string resultKey)
        {
            DomainModel.SourceFormat result = _scenarioContext[resultKey] as SourceFormat;

            result.SourceFormatDimensionStructure.DimensionStructure.Id
               .Should()
               .NotBe(0);
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureIsNotNull(
            string resultName)
        {
            DomainModel.SourceFormat result = _scenarioContext[resultName] as SourceFormat;
            // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes.Should().NotBeNull();
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure length")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureLength(
            string resultName,
            int expectedLength)
        {
            DomainModel.SourceFormat result = _scenarioContext[resultName] as SourceFormat;
            // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes.Count.Should().Be(expectedLength);
        }

        [Then(@"SourceFormat result's DimensionStructureTree has DimensionStructure under given node")]
        public async Task SourceFormatResultsDimensionStructureTreeHasDimensionStructureUnderGivenNode(
            Table table)
        {
        }

        [Then(@"a DimensionStructure is child of RootDimensionStructure")]
        public async Task ADimensionStructureIsChildOfRootDimensionStructure(Table table)
        {
            ADimensionStructureIsChildOfRootDimensionStructureEntity instance = table
               .CreateInstance<ADimensionStructureIsChildOfRootDimensionStructureEntity>();

            DomainModel.SourceFormat sourceFormatQuery = new DomainModel.SourceFormat
            {
                Name = instance.SourceFormatName,
            };
            DomainModel.SourceFormat sourceFormat = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByNameWithRootDimensionStructureAsync(sourceFormatQuery)
               .ConfigureAwait(false);

            DomainModel.DimensionStructure childDimensionStructure = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructureByNameAsync(instance.DimensionStructureName)
               .ConfigureAwait(false);

            // bool result = await _masterDataTestHelper.DimensionStructureLinkedListHelper
            //    .IsDimensionStructureChildOfRootDimensionStructureAsync(
            //         sourceFormat.RootDimensionStructure.ChildDimensionStructures,
            //         childDimensionStructure)
            //    .ConfigureAwait(false);

            // result.Should().BeTrue();
        }

        [Then(@"DimensionStructure is RootDimensionStructure of SourceFormat")]
        public async Task DimensionStructureIsRootDimensionStructureOfSourceFormat(Table table)
        {
            DimensionStructureIsRootDimensionStructureOfSourceFormatEntity instance =
                table.CreateInstance<DimensionStructureIsRootDimensionStructureOfSourceFormatEntity>();

            DomainModel.DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructureByNameWithSourceFormatsAsync(instance.Name)
               .ConfigureAwait(false);

            // SourceFormat sourceFormat = result.SourceFormatsRootDimensionStructures.FirstOrDefault(
            //     p => p.Name.Equals(instance.SourceFormatName));

            // sourceFormat.Should().NotBeNull();
        }

        [Then(@"DimensionStructure property equals to")]
        public async Task DimensionStructurePropertyEqualsTo(Table table)
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
        public async Task DimensionStructurePropertyIsNotNull(Table table)
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

        [Then(@"DimensionStructure property does not equal to")]
        public async Task DimensionStructurePropertyDoesNotEqualTo(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(
                string key,
                string propertyName,
                string notEqualTo)>();

            DimensionStructure result = _scenarioContext[instance.key] as DimensionStructure;
            Check.IsNotNull(result);

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
    }
}