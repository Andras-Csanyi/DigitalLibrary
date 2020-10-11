// // <copyright file="DimensionStructureFeature.GetDimensionStructureByIdAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
//
//     using FluentAssertions;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Test cases covering GetDimensionIdByIdAsync method validation.
//     /// </summary>
//     public partial class DimensionStructureFeature
//     {
//         [Scenario]
//         public void GetDimensionStructureByIdAsync_ThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When GetDimensionStructureByIdAsync is called with null input"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.GetDimensionStructureByIdAsync(null)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException>());
//         }
//     }
// }

