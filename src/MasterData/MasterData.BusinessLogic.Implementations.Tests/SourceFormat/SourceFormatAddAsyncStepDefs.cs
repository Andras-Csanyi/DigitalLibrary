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
                    SourceFormat sourceFormat = _masterDataTestHelper
                       .SourceFormatFactory
                       .Create(instance.Name);
                    _sourceFormatBag.Add(instance.Name, sourceFormat);
                    break;

                case DomainObjectTypesStringEnum.DimensionStructure:
                    DimensionStructure dimensionStructure = _masterDataTestHelper
                       .DimensionStructureFactory
                       .Create(instance.Name);
                    _dimensionStructureBag.Add(instance.Name, dimensionStructure);
                    break;

                default:
                    throw new ArgumentNullException($"Unknown type: {nameof(instance.Type)}");
            }
        }

        [Given(@"add a domain object to another domain object's property")]
        public async Task AddADomainObjectToAnotherDomainObjectsProperty(Table table)
        {
            AddDomainObjectToAnotherDomainObjectsPropertyEntity instance =
                table.CreateInstance<AddDomainObjectToAnotherDomainObjectsPropertyEntity>();

            if (instance.TargetDomainObjectType.Equals(DomainObjectTypesStringEnum.SourceFormat)
             && instance.DomainObjectNameToBeAdded.Equals(DomainObjectTypesStringEnum.DimensionStructure)
             && instance.TargetDomainObjectPropName.Equals(SourceFormatPropertiesStruct.RootDimensionStructure)
            )
            {
                SourceFormat targetSourceFormat = await GetTargetSourceFormat(
                        instance.TargetDomainObjectName,
                        instance.TargetDomainObjectSource)
                   .ConfigureAwait(false);

                DimensionStructure toBeAddedDimensionStructure = await GetTargetDimensionStructure(
                        instance.DomainObjectNameToBeAdded,
                        instance.DomainObjectSource)
                   .ConfigureAwait(false);

                if (instance.DomainObjectSource.Equals(DomainObjectSourceStringEnum.Bag))
                {
                    targetSourceFormat.RootDimensionStructure = toBeAddedDimensionStructure;
                }
                else
                {
                    targetSourceFormat.RootDimensionStructure = toBeAddedDimensionStructure;
                    targetSourceFormat.RootDimensionStructureId = toBeAddedDimensionStructure.Id;
                }

                if (instance.TargetDomainObjectSource.Equals(DomainObjectSourceStringEnum.Bag))
                {
                    _sourceFormatBag[instance.TargetDomainObjectName] = null;
                    _sourceFormatBag[instance.TargetDomainObjectName] = targetSourceFormat;
                }
                else
                {
                    _sourceFormatSaveOperationResultBag[instance.TargetDomainObjectName] = null;
                    _sourceFormatSaveOperationResultBag[instance.TargetDomainObjectName] = targetSourceFormat;
                }
            }
        }

        [Given(@"domain object is saved")]
        [When(@"domain object is saved")]
        public async Task DomainObjectIsSaved(Table table)
        {
            DomainObjectIsSavedEntity instance = table.CreateInstance<DomainObjectIsSavedEntity>();

            if (instance.DomainObjectType.Equals(DomainObjectTypesStringEnum.SourceFormat))
            {
                SourceFormat toSave = _sourceFormatBag
                   .FirstOrDefault(p => p.Key == instance.DomainObjectName)
                   .Value;
                SourceFormat result = await _masterDataBusinessLogic.AddSourceFormatAsync(toSave)
                   .ConfigureAwait(false);
                _sourceFormatSaveOperationResultBag.Add(instance.ResultId, result);
            }
        }

        [Given(@"sync test domain object")]
        public async Task SyncTestDataObject(Table table)
        {
            SyncTestDataObjectEntity instance = table.CreateInstance<SyncTestDataObjectEntity>();

            if (instance.Type.Equals(DomainObjectTypesStringEnum.DimensionStructure))
            {
                DimensionStructure result = await _masterDataBusinessLogic.GetDimensionStructureByNameAsync(
                        instance.Name)
                   .ConfigureAwait(false);
                _dimensionStructureStoredObjectsBag.Add(instance.ResultId, result);
            }
        }

        [Given(@"SourceFormat RootDimensionStructure has a child DimensionStructure")]
        public async Task SourceFormatRootDimensionStructureHasAChildDimensionStructure(Table table)
        {
            SourceFormatRootDimensionStructureHasAChildDimensionStructureEntity instance = table
               .CreateInstance<SourceFormatRootDimensionStructureHasAChildDimensionStructureEntity>();

            SourceFormat sourceFormat = null;
            if (instance.SourceFormatSource.Equals(DomainObjectSourceStringEnum.Bag))
            {
                sourceFormat = _sourceFormatBag.FirstOrDefault(
                        p => p.Value.Name.Equals(instance.SourceFormatName))
                   .Value;
            }

            if (instance.SourceFormatSource.Equals(DomainObjectSourceStringEnum.ResultBag))
            {
                sourceFormat = _sourceFormatSaveOperationResultBag.First(
                        p => p.Value.Name.Equals(instance.SourceFormatName))
                   .Value;
            }

            DimensionStructure dimensionStructure = null;
            if (instance.DimensionStructureSource.Equals(DomainObjectSourceStringEnum.Bag))
            {
                dimensionStructure = _dimensionStructureBag.First(
                        p => p.Value.Name.Equals(instance.ChildName))
                   .Value;
            }

            if (instance.DimensionStructureSource.Equals(DomainObjectSourceStringEnum.ResultBag))
            {
                dimensionStructure = _dimensionStructureStoredObjectsBag.First(
                        p => p.Value.Name.Equals(instance.ChildName))
                   .Value;
            }

            SourceFormat result = await _masterDataTestHelper.DimensionStructureLinkedListHelper
               .AddDimensionStructureToNodeAsync(dimensionStructure, sourceFormat, instance.NodeName)
               .ConfigureAwait(false);
        }

        [Then(@"'(.*)' SourceFormat save result is not null")]
        public async Task SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.FirstOrDefault(
                    p => p.Key.Equals(saveResultName))
               .Value;
            result.Should().NotBeNull();
        }

        [Then(@"'(.*)' SourceFormat result Id is not '(.*)'")]
        public async Task SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.FirstOrDefault(
                    p => p.Key.Equals(saveResultName))
               .Value;
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"SourceFormat result property equals to")]
        public async Task SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            SourceFormat result = _sourceFormatSaveOperationResultBag.FirstOrDefault(
                    p => p.Key.Equals(instance.Name))
               .Value;
            SourceFormat comparedTo = _sourceFormatBag.FirstOrDefault(
                p => p.Key.Equals(instance.EqualsTo)).Value;

            switch (instance.PropertyName)
            {
                case SourceFormatPropertiesStruct.RootDimensionStructure:
                    result.RootDimensionStructure.Should().NotBe(comparedTo.RootDimensionStructure);
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

            SourceFormat result = _sourceFormatSaveOperationResultBag.First(
                    p => p.Value.Name.Equals(instance.Name))
               .Value;

            switch (instance.PropertyName)
            {
                case SourceFormatPropertiesStruct.RootDimensionStructure:
                    result.RootDimensionStructure.Should().NotBeNull();
                    break;

                default:
                    throw new Exception($"There is no {instance.PropertyName} property of SourceFormat.");
            }
        }

        [Then(@"SourceFormat result's RootDimensionStructure property equals to")]
        public async Task SourceFormatResultsRootDimensionStructurePropertyEqualsTo(Table table)
        {
            SourceFormatResultRootDimensionStructurePropertyEqualsToEntity instance = table
               .CreateInstance<SourceFormatResultRootDimensionStructurePropertyEqualsToEntity>();

            SourceFormat result = _sourceFormatSaveOperationResultBag.First(
                    p => p.Value.Name.Equals(instance.Name))
               .Value;
            SourceFormat comparedTo = _sourceFormatBag.First(p => p.Value.Name.Equals(instance.EqualsTo)).Value;

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Id:
                    result.Id.Should().Be(comparedTo.Id);
                    break;

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
                    throw new Exception($"There is no {instance.PropertyName} of DimensionStructure.");
            }
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureIsNotNull(
            string resultName)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.First(p => p.Value.Name.Equals(resultName)).Value;
            result.RootDimensionStructure.ChildDimensionStructures.Should().NotBeNull();
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure length")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureLength(
            string resultName,
            int expectedLength)
        {
            SourceFormat result = _sourceFormatSaveOperationResultBag.First(p => p.Value.Name.Equals(resultName)).Value;
            result.RootDimensionStructure.ChildDimensionStructures.Count.Should().Be(expectedLength);
        }

        [Then(@"SourceFormat result's DimensionStructureTree has DimensionStructure under given node")]
        public async Task SourceFormatResultsDimensionStructureTreeHasDimensionStructureUnderGivenNode(
            Table table)
        {
            SourceFormatResultsDimensionStructureTreeHasDimensionStructureUnderGivenNodeEntity instance =
                table.CreateInstance<SourceFormatResultsDimensionStructureTreeHasDimensionStructureUnderGivenNodeEntity
                >();

            SourceFormat result = _sourceFormatSaveOperationResultBag
               .First(p => p.Value.Name.Equals(instance.SourceFormatName))
               .Value;

            DimensionStructure dimensionStructureResult = await _masterDataTestHelper.DimensionStructureLinkedListHelper
               .GetChildDimensionStructureFromGivenNode(
                    result,
                    instance.NodeName,
                    instance.DimensionStructureName)
               .ConfigureAwait(false);

            dimensionStructureResult.Should().NotBeNull();
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
               .GetSourceFormatByNameWithRootDimensionStructureAsync(sourceFormatQuery)
               .ConfigureAwait(false);

            DimensionStructure childDimensionStructure = await _masterDataBusinessLogic
               .GetDimensionStructureByNameAsync(instance.DimensionStructureName)
               .ConfigureAwait(false);

            bool result = await _masterDataTestHelper.DimensionStructureLinkedListHelper
               .IsDimensionStructureChildOfRootDimensionStructureAsync(
                    sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                    childDimensionStructure)
               .ConfigureAwait(false);

            result.Should().BeTrue();
        }
    }
}