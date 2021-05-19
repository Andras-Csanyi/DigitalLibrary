// // <copyright file="DimensionFeature.UpdateAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Features.Dimension
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.BusinessLogic.Features.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.MasterData.Validators.TestData;
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
//     /// Tests covering Update validation scenarios.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         [MemberData(
//             nameof(MasterData_Dimension_Validation_TestData.UpdateDimensionAsync_Validation),
//             MemberType = typeof(MasterData_Dimension_Validation_TestData))]
//         public void UpdateAsync_ThrowsWhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             Dimension dimension = null;
//             "Given there is a dimension"
//                .x(() => dimension = new Dimension
//                 {
//                     Id = id,
//                     Name = name,
//                     Description = desc,
//                     IsActive = isActive,
//                 });
//
//             Func<Task> action = null;
//             "When a dimension is updated with invalid input"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateDimensionAsync(dimension).ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
//                    .WithInnerException<ValidationException>());
//         }
//
//         [Scenario]
//         public void UpdateAsync_ThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When a dimension is updated with null input"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateDimensionAsync(null)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }



