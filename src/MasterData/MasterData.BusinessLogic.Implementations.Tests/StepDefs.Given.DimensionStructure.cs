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
    [Binding]
    public partial class StepDefs
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

            _scenarioContext.Add(instance.key, dimensionStructure);
        }

        [Given(@"DimensionStructure is saved")]
        public async Task GivenDimensionStructureIsSaved(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(string key, string resultKey)>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.key] as DimensionStructure;
            DimensionStructure result = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);
            _scenarioContext.Add(instance.resultKey, result);
        }

        [Given(@"'(.*)' DimensionStructure is added to '(.*)' SourceFormat as root DimensionStructure")]
        public async Task DimensionStructureIsAddedToSourceFormatAsRootDimensionStructure(
            string dimensionStructureKey,
            string sourceFormatKey)
        {
            DomainModel.SourceFormat sourceFormat = _scenarioContext[sourceFormatKey] as SourceFormat;
            DomainModel.DimensionStructure dimensionStructure = _scenarioContext[dimensionStructureKey]
                as DimensionStructure;

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

            _scenarioContext.Remove(sourceFormatKey);
            _scenarioContext.Add(sourceFormatKey, sourceFormat);
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

            DomainModel.SourceFormat sourceFormat = _scenarioContext[instance.sourceFormatKey] as SourceFormat;
            DomainModel.DimensionStructure dimensionStructure = _scenarioContext[instance.dimensionStructureKey]
                as DimensionStructure;

            await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddRootDimensionStructureAsync(sourceFormat.Id, dimensionStructure.Id)
               .ConfigureAwait(false);

            DomainModel.SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .GetSourceFormatByIdWithFullDimensionStructureTreeAsync(sourceFormat)
               .ConfigureAwait(false);

            _scenarioContext.Remove(instance.sourceFormatKey);
            _scenarioContext.Add(instance.sourceFormatKey, result);
        }
    }
}