// // <copyright file="DimensionStructureFeature.UpdateAsync.Validation.cs" company="Andras Csanyi">
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
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.MasterData.Validators.TestData;
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Test cases covering Update functionality validation.
//     /// </summary>
//     public partial class DimensionStructureFeature
//     {
//         [Scenario]
//         [MemberData(
//             nameof(MasterData_DimensionStructure_Validation_TestData.ModifyDimensionStructure_Validation_TestData),
//             MemberType = typeof(MasterData_DimensionStructure_Validation_TestData))]
//         public void UpdateAsync_ValidationThrowsWhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             DimensionStructure dimensionStructure = null;
//             "Given there is a modified dimension structure with invalid data"
//                .x(() => dimensionStructure = new DimensionStructure
//                 {
//                     Id = id,
//                     Name = name,
//                     Desc = desc,
//                     IsActive = isActive,
//                 });
//
//             Func<Task> action = null;
//             "When it is saved"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateDimensionStructureAsync(dimensionStructure)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>());
//         }
//
//         [Scenario]
//         public void UpdateAsync_ThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When save modified dimension structure method is called with null input"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateDimensionStructureAsync(null).ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }

