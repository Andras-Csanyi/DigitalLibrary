namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using Io.Cucumber.Messages;

    using Microsoft.EntityFrameworkCore.Internal;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    [Binding]
    public class SourceFormatAddAsyncStepDefs : MasterDataBusinessLogicFeature
    {
        public SourceFormatAddAsyncStepDefs(
            ITestOutputHelper testOutputHelper)
            : base(nameof(SourceFormatAddAsyncStepDefs), testOutputHelper)
        {
        }

        [Given(@"there is a domain object")]
        public async Task ThereIsADomainObject(Table table)
        {
            ThereIsADomainObjectEntity instance = table.CreateInstance<ThereIsADomainObjectEntity>();
            switch (instance.Type)
            {
                case DomainObjectTypesStringEnum.SourceFormat:
                    SourceFormat sourceFormat = await _masterDataTestHelper
                       .SourceFormatFactory
                       .Create(instance)
                       .ConfigureAwait(false);
                    _sourceFormatBag.Add(instance.Key, sourceFormat);
                    break;

                case DomainObjectTypesStringEnum.DimensionStructure:
                    DimensionStructure dimensionStructure = new DimensionStructure
                    {
                        Name = instance.Key,
                    };
                    _dimensionStructureBag.Add(instance.Key, dimensionStructure);
                    break;

                default:
                    throw new ArgumentNullException($"Unknown type: {nameof(instance.Type)}");
            }
        }

        [Given(@"domain object is saved")]
        [When(@"domain object is saved")]
        public async Task DomainObjectIsSaved(Table table)
        {
            DomainObjectIsSavedEntity instance = table.CreateInstance<DomainObjectIsSavedEntity>();

            switch (instance.DomainObjectType)
            {
                case DomainObjectTypesStringEnum.SourceFormat:
                    await SourceFormatDomainObjectTypeIsSaved(instance).ConfigureAwait(false);
                    break;

                case DomainObjectTypesStringEnum.DimensionStructure:
                    await DimensionStructureDomainObjectTypeIsSaved(instance).ConfigureAwait(false);
                    break;
            }
        }


        [Given(@"sync test domain object")]
        public async Task SyncTestDataObject(Table table)
        {
            SyncTestDataObjectEntity instance = table.CreateInstance<SyncTestDataObjectEntity>();

            if (instance.Type.Equals(DomainObjectTypesStringEnum.DimensionStructure))
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetDimensionStructureByNameAsync(
                        instance.Name)
                   .ConfigureAwait(false);
                _dimensionStructureStoredObjectsBag.Add(instance.ResultId, result);
            }
        }

        [Given(@"SourceFormat RootDimensionStructure has a child DimensionStructure")]
        public async Task SourceFormatRootDimensionStructureHasAChildDimensionStructure(Table table)
        {
        }

        [Given(@"'(.*)' is DimensionStructureTreeRoot of '(.*)'")]
        public async Task DimensionStructureTreeNodeIsDimensionStructureTreeRootOfSourceFormat(
            string dimensionStructureTreeNodeName,
            string sourceFormatName)
        {
            try
            {
                // DimensionStructureTreeNode dimensionStructureTreeNode = _dimensionStructureTreeNodesBag
                //    .First(p => p.Key.Equals(dimensionStructureTreeNodeName)).Value;
                // SourceFormat sourceFormat = _sourceFormatBag
                //    .First(p => p.Key.Equals(sourceFormatName)).Value;
                //
                // sourceFormat.DimensionStructureTreeRoot = dimensionStructureTreeNode;
            }
            catch (Exception e)
            {
                throw new SourceFormatStepDefException(
                    nameof(DimensionStructureTreeNodeIsDimensionStructureTreeRootOfSourceFormat),
                    e);
            }
        }

        [Then(@"'(.*)' SourceFormat save result is not null")]
        public async Task SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag[saveResultName];
            result.Should().NotBeNull();
        }

        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public async Task SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag[saveResultName];
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"SourceFormat result property equals to")]
        public async Task SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            SourceFormat result = _sourceFormatSaveOperationResultBag[instance.Key];
            SourceFormat comparedTo = _sourceFormatBag[instance.EqualsTo];

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

            SourceFormat result = _sourceFormatSaveOperationResultBag.FirstOrDefault(
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
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureIsNotNull(
            string resultName)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.First(p => p.Value.Name.Equals(resultName)).Value;
            // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes.Should().NotBeNull();
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure length")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureLength(
            string resultName,
            int expectedLength)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.First(p => p.Value.Name.Equals(resultName)).Value;
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

            SourceFormat sourceFormatQuery = new SourceFormat
            {
                Name = instance.SourceFormatName,
            };
            SourceFormat sourceFormat = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByNameWithRootDimensionStructureAsync(sourceFormatQuery)
               .ConfigureAwait(false);

            DimensionStructure childDimensionStructure = await _masterDataBusinessLogic
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

            DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .GetDimensionStructureByNameWithSourceFormatsAsync(instance.Name)
               .ConfigureAwait(false);

            // SourceFormat sourceFormat = result.SourceFormatsRootDimensionStructures.FirstOrDefault(
            //     p => p.Name.Equals(instance.SourceFormatName));

            // sourceFormat.Should().NotBeNull();
        }
    }
}