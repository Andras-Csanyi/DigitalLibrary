// // <copyright file="SourceFormatFeature.AddAsync.Validation.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Features.SourceFormat
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
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
//     /// Test cases covering Add method validation.
//     /// </summary>
//     public partial class SourceFormatFeature
//     {
//         [Scenario]
//         [MemberData(
//             nameof(MasterData_SourceFormat_Validation_TestData.AddNew),
//             MemberType = typeof(MasterData_SourceFormat_Validation_TestData))]
//         [SuppressMessage("ReSharper", "TooManyArguments", Justification = "Reviewed.")]
//         public void AddAsync_ThrowsWhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             SourceFormat sourceFormat = null;
//             Func<Task> action = null;
//
//             "Given there is a new Source Format which is not fit for validation rules"
//                .x(() => sourceFormat = new SourceFormat
//                 {
//                     Id = id,
//                     Name = name,
//                     Desc = desc,
//                     IsActive = isActive,
//                 });
//
//             "When I want to save it"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.AddSourceFormatAsync(sourceFormat).ConfigureAwait(false);
//                 });
//
//             "Then the business logic throws exception"
//                .x(() => action.Should()
//                    .ThrowExactly<MasterDataBusinessLogicAddSourceFormatAsyncOperationException>());
//         }
//
//         [Scenario]
//         public void AddAsync_ThrowsExceptionWhenInputIsNull()
//         {
//             Func<Task> action = null;
//
//             "When input is null for saving source format"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.AddSourceFormatAsync(null).ConfigureAwait(false);
//                 });
//
//             "Then it throws exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicAddSourceFormatAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }

