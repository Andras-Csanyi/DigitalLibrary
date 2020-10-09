// // <copyright file="SourceFormatFeature.UpdateAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.MasterData.Validators.TestData;
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
//     /// Test cases covering Update validation.
//     /// </summary>
//     public partial class SourceFormatFeature
//     {
//         [Scenario]
//         [MemberData(
//             nameof(MasterData_DimensionStructure_Validation_TestData.ModifyTopDimensionStructure_Validation_TestData),
//             MemberType = typeof(MasterData_DimensionStructure_Validation_TestData))]
//         public void UpdateAsync_ThrowsWhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             SourceFormat sourceFormat = null;
//             Func<Task> action = null;
//
//             "Given there is a source format with invalid data"
//                .x(() => sourceFormat = new SourceFormat()
//                 {
//                     Id = id,
//                     Name = name,
//                     Desc = desc,
//                     IsActive = isActive,
//                 });
//
//             "When source format is updated"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat).ConfigureAwait(false);
//                 });
//
//             "Then the operation should throw exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
//                    .WithInnerException<ValidationException>());
//         }
//
//         [Scenario]
//         public void UpdateAsync_ThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When source format update method is called with null parameter"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateSourceFormatAsync(null).ConfigureAwait(false);
//                 });
//
//             "Then the update operation throws exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
//                    .WithInnerException<MasterDataBusinessLogicArgumentNullException>());
//         }
//     }
// }

