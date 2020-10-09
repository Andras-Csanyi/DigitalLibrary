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
                    DimensionStructure dimensionStructure = await _masterDataTestHelper
                       .DimensionStructureFactory
                       .Create(instance)
                       .ConfigureAwait(false);
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
                _dimensionStructureBag.Add(instance.ResultId, result);
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
                throw new MasterDataStepDefinitionException(
                    nameof(DimensionStructureTreeNodeIsDimensionStructureTreeRootOfSourceFormat),
                    e);
            }
        }

        [Given(@"SourceFormat's root DimensionStructure is")]
        public async Task SourceFormatsRootDimensionStructureIs(Table table)
        {
            SourceFormatsRootDimensionStructureIsEntity instance =
                table.CreateInstance<SourceFormatsRootDimensionStructureIsEntity>();

            SourceFormat sourceFormat = _sourceFormatBag[instance.SourceFormatKey];

            DimensionStructure dimensionStructure = _dimensionStructureBag[instance.DimensionStructureKey];

            SourceFormatDimensionStructure sourceFormatDimensionStructure = new SourceFormatDimensionStructure
            {
                SourceFormat = sourceFormat,
                DimensionStructure = dimensionStructure,
            };
            sourceFormat.SourceFormatDimensionStructure = sourceFormatDimensionStructure;

            _sourceFormatBag.Remove(instance.SourceFormatKey);
            _sourceFormatBag.Add(instance.SourceFormatKey, sourceFormat);
        }

        [Given(@"DimensionStructure is saved")]
        public async Task DimensionStructureIsSaved(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            DimensionStructure toBeSaved = _dimensionStructureBag[instance.key];
            DimensionStructure saved = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddDimensionStructureAsync(toBeSaved)
               .ConfigureAwait(false);
            _dimensionStructureBag.Add(instance.resultKey, saved);
        }

        [Given(@"SourceFormat is saved")]
        [When(@"SourceFormat is saved")]
        public async Task SourceFormatIsSaved(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            SourceFormat toBeSaved = _sourceFormatBag[instance.key];
            SourceFormat saved = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddSourceFormatAsync(toBeSaved)
               .ConfigureAwait(false);
            _sourceFormatBag.Add(instance.resultKey, saved);
        }

        [Given(@"'(.*)' DimensionStructure is added to '(.*)' SourceFormat as root DimensionStructure")]
        public async Task DimensionStructureIsAddedToSourceFormatAsRootDimensionStructure(
            string dimensionStructureKey,
            string sourceFormatKey)
        {
            SourceFormat sourceFormat = _sourceFormatBag[sourceFormatKey];
            DimensionStructure dimensionStructure = _dimensionStructureBag[dimensionStructureKey];

            if (dimensionStructure.Id != 0)
            {
                SourceFormatDimensionStructure sourceFormatDimensionStructure = new SourceFormatDimensionStructure
                {
                    DimensionStructure = dimensionStructure,
                    DimensionStructureId = dimensionStructure.Id,
                    SourceFormat = sourceFormat,
                };
                sourceFormat.SourceFormatDimensionStructure = sourceFormatDimensionStructure;
            }
            else
            {
                SourceFormatDimensionStructure sourceFormatDimensionStructure = new SourceFormatDimensionStructure
                {
                    DimensionStructure = dimensionStructure,
                    SourceFormat = sourceFormat,
                };
                sourceFormat.SourceFormatDimensionStructure = sourceFormatDimensionStructure;
            }

            _sourceFormatBag.Remove(sourceFormatKey);
            _sourceFormatBag.Add(sourceFormatKey, sourceFormat);
        }

        [Given(@"there is a SourceFormat domain object")]
        public async Task ThereIsASourceFormatDomainObject(Table table)
        {
            var instance = table.CreateInstance<(
                string key,
                string name,
                string desc,
                int isActive)>();

            SourceFormat sourceFormat = new SourceFormat
            {
                Name = instance.name ?? stringHelper.GetRandomString(3),
                Desc = instance.desc ?? stringHelper.GetRandomString(3),
                IsActive = instance.isActive,
            };

            if (string.IsNullOrEmpty(instance.key) || string.IsNullOrWhiteSpace(instance.key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _sourceFormatBag.Add(instance.key, sourceFormat);
        }

        [Given(@"there is a DimensionStructure domain object")]
        public async Task ThereIsADimensionStructureDomainObject(Table table)
        {
            var instance = table.CreateInstance<(
                string key,
                string name,
                string desc,
                int isActive)>();
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = instance.name ?? stringHelper.GetRandomString(4),
                Desc = instance.desc ?? stringHelper.GetRandomString(4),
                IsActive = instance.isActive,
            };

            if (string.IsNullOrEmpty(instance.key) || string.IsNullOrWhiteSpace(instance.key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _dimensionStructureBag.Add(instance.key, dimensionStructure);
        }

        [Given(@"DimensionStructure is added to SourceFormat as root dimensionstructure")]
        public async Task DimensionStructureIsAddedToSourceFormatAsRootDimensionStructure(Table table)
        {
            var instance = table.CreateInstance<(
                string sourceFormatKey,
                string dimensionStructureKey)>();

            if (string.IsNullOrEmpty(instance.sourceFormatKey)
             || string.IsNullOrWhiteSpace(instance.sourceFormatKey)
             || string.IsNullOrEmpty(instance.dimensionStructureKey)
             || string.IsNullOrWhiteSpace(instance.dimensionStructureKey))
            {
                string msg = $"Either {nameof(instance.sourceFormatKey)} or " +
                    $"{nameof(instance.dimensionStructureKey)} are null. Or both.";
                throw new MasterDataStepDefinitionException(msg);
            }

            SourceFormat sourceFormat = _sourceFormatBag[instance.sourceFormatKey];
            DimensionStructure dimensionStructure = _dimensionStructureBag[instance.dimensionStructureKey];

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureAsync(sourceFormat.Id, dimensionStructure.Id)
               .ConfigureAwait(false);

            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _sourceFormatBag.Remove(instance.sourceFormatKey);
            _sourceFormatBag.Add(instance.sourceFormatKey, result);
        }

        [When(@"SourceFormat is requested with DimensionStructure tree")]
        public async Task SourceFormatIsRequestedWithDimensionStructureTree(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            SourceFormat withoutTree = _sourceFormatBag[instance.key];

            SourceFormat requestedWithTree = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(withoutTree)
               .ConfigureAwait(false);

            _sourceFormatBag.Add(instance.resultKey, requestedWithTree);
        }

        [Then(@"'(.*)' SourceFormat save result is not null")]
        public async Task SourceFormatSaveResultIsNotNull(string saveResultName)
        {
            SourceFormat result = _sourceFormatBag[saveResultName];
            result.Should().NotBeNull();
        }

        [Then(@"'(.*)' SourceFormat save result Id is not '(.*)'")]
        public async Task SourceFormatSaveResultIdIsNotZero(string saveResultName, int notEqualsTo)
        {
            SourceFormat result = _sourceFormatBag[saveResultName];
            result.Id.Should().NotBe(notEqualsTo);
        }

        [Then(@"SourceFormat result property equals to")]
        public async Task SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            SourceFormat result = _sourceFormatBag[instance.Key];
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

            SourceFormat result = _sourceFormatBag.FirstOrDefault(
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

            SourceFormat result = _sourceFormatBag[instance.Key];
            DimensionStructure comparedTo = _dimensionStructureBag[instance.EqualsTo];

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
            SourceFormat result = _sourceFormatBag[resultKey];

            result.SourceFormatDimensionStructure.DimensionStructure.Id
               .Should()
               .NotBe(0);
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureIsNotNull(
            string resultName)
        {
            SourceFormat result = _sourceFormatBag.First(p => p.Value.Name.Equals(resultName)).Value;
            // result.DimensionStructureTreeRoot.ChildDimensionStructureTreeNodes.Should().NotBeNull();
        }

        [Then(@"<.*> SourceFormat result's RootDimensionStructure ChildDimensionStructure length")]
        public async Task GivenSourceFormatResultRootDimensionStructureChildDimensionStructureLength(
            string resultName,
            int expectedLength)
        {
            SourceFormat result = _sourceFormatBag.First(p => p.Value.Name.Equals(resultName)).Value;
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