// // <copyright file="DimensionStructureFeature.AddAsync.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
// {
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//
//     using FluentAssertions;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Test cases covering Add functionality.
//     /// </summary>
//     public partial class DimensionStructureFeature
//     {
//         [Scenario]
//         public async Task AddAsync_AddsTheDimensionStructure()
//         {
//             DimensionStructure dimensionStructure = null;
//             "Given there is a dimension structure"
//                .x(() => dimensionStructure = new DimensionStructure
//                 {
//                     Name = "name",
//                     Desc = "desc",
//                     IsActive = 1,
//                 });
//
//             DimensionStructure result = null;
//             "When it is saved in the database"
//                .x(async () => result = await _masterDataBusinessLogic.AddDimensionStructureAsync(dimensionStructure)
//                    .ConfigureAwait(false));
//
//             "Then returning result is not null".x(() => result.Should().NotBeNull());
//             "And returning result id is not 0".x(() => result.Id.Should().NotBe(0));
//             "And returning result name equals to the original's name"
//                .x(() => result.Name.Should().Be(dimensionStructure.Name));
//             "And returning result desc equals to the original's desc"
//                .x(() => result.Desc.Should().Be(dimensionStructure.Desc));
//             "And returning result is active value equals to the original's is active value"
//                .x(() => result.IsActive.Should().Be(dimensionStructure.IsActive));
//         }
//     }
// }

