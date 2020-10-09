// <copyright file="DimensionStructureFeature.AddAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    /// <summary>
    /// Test cases covering Add functionality.
    /// </summary>
    [Binding]
    public partial class MasterDataBusinessLogicImplementationTests
    {
        [Given(@"there is a DimensionStructure domain object")]
        public async Task ThereIsADimensionStructureDomainObject(Table table)
        {
            var instance = table.CreateInstance<(
                string key,
                string name,
                string desc,
                int isActive)>();
            DomainModel.DimensionStructure dimensionStructure = new DomainModel.DimensionStructure
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

        [Given(@"there is a domain object")]
        public async Task ThereIsADomainObject(Table table)
        {
            ThereIsADomainObjectEntity instance = table.CreateInstance<ThereIsADomainObjectEntity>();
            switch (instance.Type)
            {
                case DomainObjectTypesStringEnum.SourceFormat:
                    DomainModel.SourceFormat sourceFormat = await _masterDataTestHelper
                       .SourceFormatFactory
                       .Create(instance)
                       .ConfigureAwait(false);
                    _sourceFormatBag.Add(instance.Key, sourceFormat);
                    break;

                case DomainObjectTypesStringEnum.DimensionStructure:
                    DomainModel.DimensionStructure dimensionStructure = await _masterDataTestHelper
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
                DomainModel.DimensionStructure result = await _masterDataBusinessLogic
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

            DomainModel.SourceFormat sourceFormat = _sourceFormatBag[instance.SourceFormatKey];

            DomainModel.DimensionStructure dimensionStructure = _dimensionStructureBag[instance.DimensionStructureKey];

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

            DomainModel.DimensionStructure toBeSaved = _dimensionStructureBag[instance.key];
            DomainModel.DimensionStructure saved = await _masterDataBusinessLogic
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

            DomainModel.SourceFormat toBeSaved = _sourceFormatBag[instance.key];
            DomainModel.SourceFormat saved = await _masterDataBusinessLogic
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
            DomainModel.SourceFormat sourceFormat = _sourceFormatBag[sourceFormatKey];
            DomainModel.DimensionStructure dimensionStructure = _dimensionStructureBag[dimensionStructureKey];

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

            DomainModel.SourceFormat sourceFormat = new DomainModel.SourceFormat
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

            DomainModel.SourceFormat sourceFormat = _sourceFormatBag[instance.sourceFormatKey];
            DomainModel.DimensionStructure dimensionStructure = _dimensionStructureBag[instance.dimensionStructureKey];

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureAsync(sourceFormat.Id, dimensionStructure.Id)
               .ConfigureAwait(false);

            DomainModel.SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _sourceFormatBag.Remove(instance.sourceFormatKey);
            _sourceFormatBag.Add(instance.sourceFormatKey, result);
        }
    }
}