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
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Xunit.Abstractions;

    /// <summary>
    /// Test cases covering Add functionality.
    /// </summary>
    public partial class StepDefs
    {
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


        [Given(@"SourceFormat RootDimensionStructure has a child DimensionStructure")]
        public async Task SourceFormatRootDimensionStructureHasAChildDimensionStructure(Table table)
        {
        }

        [Given(@"SourceFormat's root DimensionStructure is")]
        public async Task SourceFormatsRootDimensionStructureIs(Table table)
        {
            SourceFormatsRootDimensionStructureIsEntity instance =
                table.CreateInstance<SourceFormatsRootDimensionStructureIsEntity>();

            DomainModel.SourceFormat sourceFormat = _scenarioContext[instance.SourceFormatKey] as SourceFormat;

            DomainModel.DimensionStructure dimensionStructure = _scenarioContext[instance.DimensionStructureKey]
                as DimensionStructure;

            SourceFormatDimensionStructure sourceFormatDimensionStructure = new SourceFormatDimensionStructure
            {
                SourceFormat = sourceFormat,
                DimensionStructure = dimensionStructure,
            };
            sourceFormat.SourceFormatDimensionStructure = sourceFormatDimensionStructure;

            _scenarioContext.Remove(instance.SourceFormatKey);
            _scenarioContext.Add(instance.SourceFormatKey, sourceFormat);
        }

        [Given(@"SourceFormat is saved")]
        [When(@"SourceFormat is saved")]
        public async Task SourceFormatIsSaved(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            DomainModel.SourceFormat toBeSaved = _scenarioContext[instance.key] as SourceFormat;
            DomainModel.SourceFormat saved = await _masterDataBusinessLogic
               .MasterDataSourceFormatBusinessLogic
               .AddSourceFormatAsync(toBeSaved)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.resultKey, saved);
        }

        [Given(@"there is a SourceFormat domain object")]
        public async Task ThereIsASourceFormatDomainObject(Table table)
        {
            var instance = table.CreateInstance<(
                string key,
                string nameProperty,
                string descProperty,
                int isActiveProperty)>();

            DomainModel.SourceFormat sourceFormat = new DomainModel.SourceFormat
            {
                Name = instance.nameProperty ?? stringHelper.GetRandomString(3),
                Desc = instance.descProperty ?? stringHelper.GetRandomString(3),
                IsActive = instance.isActiveProperty,
            };

            if (string.IsNullOrEmpty(instance.key) || string.IsNullOrWhiteSpace(instance.key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _scenarioContext.Add(instance.key, sourceFormat);
        }
    }
}