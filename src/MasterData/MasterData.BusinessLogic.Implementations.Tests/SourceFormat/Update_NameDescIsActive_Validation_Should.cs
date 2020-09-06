// // <copyright file="Update_NameDescIsActive_Validation_Should.cs" company="Andras Csanyi">
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
//     using Xunit;
//
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class Update_SourceFormat_Validation_Should : SourceFormatFeature
//     {
//         public Update_SourceFormat_Validation_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(Update_SourceFormat_Validation_Should);
//
//         [Theory]
//         [MemberData(
//             nameof(MasterData_DimensionStructure_Validation_TestData.ModifyTopDimensionStructure_Validation_TestData),
//             MemberType = typeof(MasterData_DimensionStructure_Validation_TestData))]
//         public void ThrowException_WhenInputIsInvalid(
//             long id,
//             string name,
//             string desc,
//             int isActive)
//         {
//             // Arrange
//             SourceFormat sourceFormat = new SourceFormat()
//             {
//                 Id = id,
//                 Name = name,
//                 Desc = desc,
//                 IsActive = isActive,
//             };
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await _masterDataBusinessLogic.UpdateSourceFormatAsync(sourceFormat).ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
//                .WithInnerException<ValidationException>();
//         }
//
//         [Fact]
//         public void ThrowException_WhenInputIsNull()
//         {
//             // Arrange
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await _masterDataBusinessLogic.UpdateSourceFormatAsync(null).ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException>()
//                .WithInnerException<MasterDataBusinessLogicArgumentNullException>();
//         }
//     }
// }

