// // <copyright file="DimensionFeature.AddAsync.Validation.cs" company="Andras Csanyi">
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
//     /// Test cases covering Add functionality related validations.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         [MemberData(
//             nameof(MasterData_Dimension_Validation_TestData.AddDimensionAsync_Validation),
//             MemberType = typeof(MasterData_Dimension_Validation_TestData))]
//         public void AddAsync_ValidationThrowsWhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             Dimension dimension = null;
//             "Given there is a dimension populate with various invalid values"
//                .x(() => dimension = new Dimension
//                 {
//                     Id = id,
//                     Name = name,
//                     Description = desc,
//                     IsActive = isActive,
//                 });
//
//             Func<Task> action = null;
//             "When dimension is saved"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.AddDimensionAsync(dimension).ConfigureAwait(false);
//                 });
//
//             "Then it throws exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionAsyncOperationException>()
//                    .WithInnerException<ValidationException>());
//         }
//
//         [Scenario]
//         public void AddAsync_ValidationThrowsWhenInputIsNull()
//         {
//             Func<Task> action = null;
//             "When the input is null"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.AddDimensionAsync(null).ConfigureAwait(false);
//                 });
//
//             "Then it throws exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicAddDimensionAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }

