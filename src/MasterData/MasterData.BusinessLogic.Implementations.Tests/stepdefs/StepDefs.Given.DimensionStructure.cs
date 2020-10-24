// <copyright file="DimensionStructureFeature.AddAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.stepdefs
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    ///     Test cases covering Add functionality.
    /// </summary>
    [Binding]
    public partial class StepDefs
    {
        [Given(@"DimensionStructure is added to DimensionStructure as child in tree of SourceFormat")]
        public async Task GivenDimensionStructureIsAddedToDimensionStructureAsChildInTreeOfSourceFormat(Table table)
        {
            var instance = table.CreateInstance<(
                string childKey,
                string parentKey,
                string sourceFormatKey)>();

            DimensionStructure child = _scenarioContext[instance.childKey] as DimensionStructure;

            DimensionStructure parent = _scenarioContext[instance.parentKey] as DimensionStructure;

            SourceFormat sourceFormat = _scenarioContext[instance.sourceFormatKey] as SourceFormat;

            await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic
               .AddDimensionStructureToParentAsChildInSourceFormatAsync(child.Id, parent.Id, sourceFormat.Id)
               .ConfigureAwait(false);
        }

        [Given(@"DimensionStructure is saved")]
        [When(@"DimensionStructure is saved")]
        public async Task GivenDimensionStructureIsSaved(Table table)
        {
            Check.IsNotNull(table);

            var instance = table.CreateInstance<(string key, string resultKey)>();

            DimensionStructure dimensionStructure = _scenarioContext[instance.key] as DimensionStructure;
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.resultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.resultKey, e);
            }
        }

        [Given(@"there is a DimensionStructure domain object")]
        public void ThereIsADimensionStructureDomainObject(Table table)
        {
            var instance = table.CreateInstance<ThereIsADimensionStructureDomainobjectEntity>();
            DomainModel.DimensionStructure dimensionStructure = _masterDataTestHelper
               .DimensionStructureFactory
               .Create(instance);

            if (string.IsNullOrEmpty(instance.Key) || string.IsNullOrWhiteSpace(instance.Key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _scenarioContext.Add(instance.Key, dimensionStructure);
        }

        [Given(@"there is a saved DimensionStructure domain object")]
        public async Task ThereIsASavedDimensionStructureDomainObject(Table table)
        {
            var instance = table.CreateInstance<ThereIsASavedDimensionStructureDomainobjectEntity>();
            DomainModel.DimensionStructure dimensionStructure = _masterDataTestHelper
               .DimensionStructureFactory
               .Create(instance);

            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.ResultKey, result);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.ResultKey, e);
            }
        }

        [Given(@"DimensionStructure is deleted from the tree")]
        public async Task DimensionStructureIsDeletedFromTheTree(Table table)
        {
            var instance = table.CreateInstance<(
                string dimensionStructureKey,
                string sourceFormatKey,
                string resultKey)>();

            DimensionStructure toBeDeleted = _scenarioContext[instance.dimensionStructureKey] as DimensionStructure;
            SourceFormat sourceFormat = _scenarioContext[instance.sourceFormatKey] as SourceFormat;

            try
            {
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteFromTree(toBeDeleted.Id, sourceFormat.Id)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.resultKey, SUCCESS);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.resultKey, e);
            }
        }
    }
}