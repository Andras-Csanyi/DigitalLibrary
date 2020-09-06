// // <copyright file="GetDimensionStructureByIdAsync_Validation_Should.cs" company="Andras Csanyi">
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
//     using Xunit;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class GetDimensionStructureByIdAsync_Validation_Should : SourceFormatFeature
//     {
//         public GetDimensionStructureByIdAsync_Validation_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(GetDimensionStructureByIdAsync_Validation_Should);
//
//         [Fact]
//         public void ThrowException_WhenInputIsNull()
//         {
//             // Arrange
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await _masterDataBusinessLogic.GetDimensionStructureByIdAsync(null)
//                    .ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException>();
//         }
//     }
// }

