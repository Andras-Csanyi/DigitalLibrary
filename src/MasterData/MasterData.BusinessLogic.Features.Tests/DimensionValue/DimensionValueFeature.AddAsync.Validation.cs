// // <copyright file="DimensionValueFeature.AddAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Features.DimensionValue
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.BusinessLogic.Features.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//
//     using FluentAssertions;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Tests covering Add validation scenarios.
//     /// </summary>
//     public partial class DimensionValueFeature
//     {
//         [Scenario]
//         [InlineData(0, 0)]
//         [InlineData(100, 100)]
//         public void AddAsync_ThrowsWhenInputIsNull(
//             long dimensionId,
//             long dimensionValueId)
//         {
//             DimensionValue dimensionValue = null;
//             "Given there is a dimension value"
//                .x(() => dimensionValue = new DimensionValue
//                 {
//                     Id = dimensionValueId,
//                 });
//
//             Func<Task> action = null;
//             "When adding dimension value to dimension is called"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.AddDimensionValueAsync(dimensionValue, dimensionId)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then it throws exception"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicAddDimensionValueAsyncOperationException>());
//         }
//     }
// }



