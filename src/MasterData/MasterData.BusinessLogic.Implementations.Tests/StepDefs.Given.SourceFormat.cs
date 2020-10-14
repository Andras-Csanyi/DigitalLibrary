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

    /// <summary>
    ///     Test cases covering Add functionality.
    /// </summary>
    public partial class StepDefs
    {
        [Given(@"SourceFormat is saved")]
        [When(@"SourceFormat is saved")]
        public async Task SourceFormatIsSaved(Table table)
        {
            var instance = table.CreateInstance<(string key, string resultKey)>();

            DomainModel.SourceFormat toBeSaved = _scenarioContext[instance.key] as SourceFormat;
            try
            {
                SourceFormat saved = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddSourceFormatAsync(toBeSaved)
                   .ConfigureAwait(false);
                _scenarioContext.Add(instance.resultKey, saved);
            }
            catch (Exception e)
            {
                _scenarioContext.Add(instance.resultKey, e);
            }
        }

        [Given(@"SourceFormat RootDimensionStructure has a child DimensionStructure")]
        public void SourceFormatRootDimensionStructureHasAChildDimensionStructure(Table table)
        {
        }

        [Given(@"there is a SourceFormat domain object")]
        public void ThereIsASourceFormatDomainObject(Table table)
        {
            var instance = table.CreateInstance<ThereIsASourceFormatDomainObjectEntity>();

            DomainModel.SourceFormat sourceFormat = _masterDataTestHelper
               .SourceFormatFactory
               .Create(instance);

            if (string.IsNullOrEmpty(instance.Key) || string.IsNullOrWhiteSpace(instance.Key))
            {
                string msg = $"Key is empty or null";
                throw new MasterDataStepDefinitionException(msg);
            }

            _scenarioContext.Add(instance.Key, sourceFormat);
        }
    }
}