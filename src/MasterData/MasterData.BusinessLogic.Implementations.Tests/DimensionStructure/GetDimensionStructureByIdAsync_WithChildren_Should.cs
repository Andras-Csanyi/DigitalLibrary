// // <copyright file="GetDimensionStructureByIdAsync_WithChildren_Should.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
// {
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
//     using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
//
//     using FluentAssertions;
//
//     using Xunit;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class GetDimensionStructureByIdAsync_WithChildren_Should : SourceFormatFeature
//     {
//         public GetDimensionStructureByIdAsync_WithChildren_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(GetDimensionStructureByIdAsync_WithChildren_Should);
//
//         [Fact]
//         public async Task Return_WithChildren_WhenItIsNotRootDimensionStructure()
//         {
//             // Arrange
//             DimensionStructure dimensionStructureForId = await _masterDataBusinessLogic.GetDimensionStructureByNameAsync(
//                     MasterDataDataSample.HungarianBusinessPartnerAddressName)
//                .ConfigureAwait(false);
//
//             // Act
//             DimensionStructureQueryObject dimensionStructureQueryObject = new DimensionStructureQueryObject
//             {
//                 GetDimensionsStructuredById = dimensionStructureForId.Id,
//                 IncludeChildrenWhenGetDimensionStructureById = true,
//             };
//             DimensionStructure result = await _masterDataBusinessLogic
//                .GetDimensionStructureByIdAsync(dimensionStructureQueryObject)
//                .ConfigureAwait(false);
//
//             // Assert
//             result.ChildDimensionStructures.Should().NotBeNullOrEmpty();
//             result.ChildDimensionStructures.Count.Should().Be(3);
//         }
//
//         [Fact]
//         public async Task Return_WithChildren_WhenItIsRootDimension()
//         {
//             // Arrange
//             DimensionStructure dimensionStructureForId = await _masterDataBusinessLogic.GetDimensionStructureByNameAsync(
//                     MasterDataDataSample.HungarianBusinessPartnerRootDimensionStructureName)
//                .ConfigureAwait(false);
//
//             // Act
//             DimensionStructureQueryObject dimensionStructureQueryObject = new DimensionStructureQueryObject
//             {
//                 GetDimensionsStructuredById = dimensionStructureForId.Id,
//                 IncludeChildrenWhenGetDimensionStructureById = true,
//             };
//             DimensionStructure result = await _masterDataBusinessLogic
//                .GetDimensionStructureByIdAsync(dimensionStructureQueryObject)
//                .ConfigureAwait(false);
//
//             // Assert
//             result.ChildDimensionStructures.Should().NotBeNullOrEmpty();
//             result.ChildDimensionStructures.Count.Should().Be(4);
//         }
//     }
// }

