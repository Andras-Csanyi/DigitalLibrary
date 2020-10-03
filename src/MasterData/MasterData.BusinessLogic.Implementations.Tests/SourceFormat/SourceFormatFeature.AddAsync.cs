// <copyright file="SourceFormatFeature.AddAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Io.Cucumber.Messages;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Test cases covering AddAsync method.
    /// </summary>
    public class SourceFormatFeature : MasterDataBusinessLogicFeature
    {
        private const string testInfo = nameof(SourceFormatFeature);

        public SourceFormatFeature(ITestOutputHelper testOutputHelper) : base(testInfo, testOutputHelper)
        {
        }

        [Fact]
        public async Task Testing()
        {
            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = "existing",
                Desc = "existing",
                IsActive = 1,
            };

            DimensionStructure dimensionStructureResult = await _masterDataBusinessLogic
               .MasterDataDimensionStructureBusinessLogic.AddDimensionStructureAsync(dimensionStructure)
               .ConfigureAwait(false);

            SourceFormat sourceFormat = new SourceFormat
            {
                Name = "sourceformat",
                Desc = "desc",
                IsActive = 1,
                SourceFormatDimensionStructure = new SourceFormatDimensionStructure
                {
                    DimensionStructure = new DimensionStructure
                    {
                        Name = "dimension structure first",
                        Desc = "desc",
                        IsActive = 1,
                        ChildDimensionStructuresReferences = new List<DimensionStructureDimensionStructure>
                        {
                            new DimensionStructureDimensionStructure
                            {
                                ChildDimensionStructure = new DimensionStructure
                                {
                                    Name = "child 1", Desc = "desc"
                                },
                            },
                            new DimensionStructureDimensionStructure
                            {
                                ChildDimensionStructureId = dimensionStructureResult.Id,
                            },
                        },
                    },
                },
            };

            SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
               .AddSourceFormatAsync(sourceFormat)
               .ConfigureAwait(false);
        }
    }
}