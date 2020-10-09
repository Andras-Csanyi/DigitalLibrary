namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    public partial class MasterDataBusinessLogicImplementationTests
    {
        [Then(@"'(.*)' SourceFormat save result is not null")]
        public async Task SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            DomainModel.SourceFormat result = _sourceFormatBag[saveResultName];
            result.Should().NotBeNull();
        }

        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public async Task SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            DomainModel.SourceFormat result = _sourceFormatBag[saveResultName];
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"SourceFormat result property equals to")]
        public async Task SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _sourceFormatBag[instance.Key];
            DomainModel.SourceFormat comparedTo = _sourceFormatBag[instance.EqualsTo];

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

            DomainModel.SourceFormat result = _sourceFormatBag.FirstOrDefault(
                    p => p.Key.Equals(instance.Name))
               .Value;

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

            DomainModel.SourceFormat result = _sourceFormatBag[instance.Key];
            DomainModel.DimensionStructure comparedTo = _dimensionStructureBag[instance.EqualsTo];

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
            DomainModel.SourceFormat result = _sourceFormatBag[resultKey];

            result.SourceFormatDimensionStructure.DimensionStructure.Id
               .Should()
               .NotBe(0);
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureIsNotNull(
            string resultName)
        {
            DomainModel.SourceFormat result = _sourceFormatBag.First(p => p.Value.Name.Equals(resultName)).Value;
            // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes.Should().NotBeNull();
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure length")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureLength(
            string resultName,
            int expectedLength)
        {
            DomainModel.SourceFormat result = _sourceFormatBag.First(p => p.Value.Name.Equals(resultName)).Value;
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
    }
}