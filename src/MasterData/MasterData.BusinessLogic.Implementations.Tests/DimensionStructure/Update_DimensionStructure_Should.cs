// // <copyright file="Update_DimensionStructure_Should.cs" company="Andras Csanyi">
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
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using Xunit;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class Update_DimensionStructure_Should : SourceFormatFeature
//     {
//         public Update_DimensionStructure_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(Update_DimensionStructure_Should);
//
//         [Fact]
//         public void ThrowException_WhenThereIsNoSuchEntity()
//         {
//             // Arrange
//             DimensionStructure orig = new DimensionStructure
//             {
//                 Id = 100,
//                 Name = "name",
//                 Desc = "desc",
//                 IsActive = 1,
//             };
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await _masterDataBusinessLogic.UpdateDimensionStructureAsync(orig).ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException>()
//                .WithInnerException<GuardException>();
//         }
//
//         [Fact]
//         public async Task Update()
//         {
//             // Arrange
//             string updateName = "update name";
//             string updateDesc = "update desc";
//             int updateIsActive = 0;
//
//             DimensionStructure orig = new DimensionStructure
//             {
//                 Name = "name",
//                 Desc = "desc",
//                 IsActive = 1,
//             };
//             DimensionStructure origResult = await _masterDataBusinessLogic.AddDimensionStructureAsync(
//                 orig).ConfigureAwait(false);
//
//             origResult.Name = updateName;
//             origResult.Desc = updateDesc;
//             origResult.IsActive = updateIsActive;
//
//             // Act
//             DimensionStructure updatedResult = await _masterDataBusinessLogic.UpdateDimensionStructureAsync(
//                 origResult).ConfigureAwait(false);
//
//             // Assert
//             updatedResult.Id.Should().Be(origResult.Id);
//             updatedResult.Name.Should().Be(updateName);
//             updatedResult.Desc.Should().Be(updateDesc);
//             updatedResult.IsActive.Should().Be(updateIsActive);
//         }
//     }
// }

