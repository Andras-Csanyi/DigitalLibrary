// // <copyright file="DimensionFeature.DeleteAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using FluentValidation;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Tests covering Delete validation.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         public void DeleteAsync_ThrowsWhenInputIsInvalid()
//         {
//             Dimension dimension = null;
//             "Given there is a dimension with invalid data for deletion"
//                .x(() => dimension = new Dimension
//                 {
//                     Id = 0,
//                 });
//
//             // Act
//             Func<Task> action = null;
//             "When I try to delete the dimension based on invalid input data"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.DeleteDimensionAsync(dimension).ConfigureAwait(false);
//                 });
//
//             "Then a MasterDataBusinessLogicDeleteDimensionAsyncOperationException with is thrown"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
//                    .WithInnerException<ValidationException>());
//         }
//
//         [Scenario]
//         public void DeleteAsync_ThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When I try to delete a dimension with null input"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.DeleteDimensionAsync(null).ConfigureAwait(false);
//                 });
//
//             "Then a MasterDataBusinessLogicDeleteDimensionAsyncOperationException is thrown"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }

