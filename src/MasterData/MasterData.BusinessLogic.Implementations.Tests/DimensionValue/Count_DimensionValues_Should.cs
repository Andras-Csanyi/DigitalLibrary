// // <copyright file="Count_DimensionValues_Should.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
// {
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//
//     using FluentAssertions;
//
//     using Xunit;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class Count_DimensionValues_Should : SourceFormatFeature
//     {
//         public Count_DimensionValues_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(Count_DimensionValues_Should);
//
//         [Fact]
//         public async Task ReturnDimensionValuesCount_WhenASingleDimensionValueIsInTheSystem()
//         {
//             // Arrange
//             Dimension dimension = new Dimension
//             {
//                 Name = "name",
//                 Description = "desc",
//                 IsActive = 1,
//             };
//             Dimension dimensionResult = await _masterDataBusinessLogic
//                .AddDimensionAsync(dimension)
//                .ConfigureAwait(false);
//
//             DimensionValue dimensionValue = new DimensionValue
//             {
//                 Value = "dimval",
//             };
//
//             DimensionValue dimensionValueResult = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimensionValue,
//                     dimensionResult.Id).ConfigureAwait(false);
//
//             // Act
//             long result = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
//
//             // Assert
//             result.Should().Be(1);
//         }
//
//         [Fact]
//         public async Task ReturnDimensionValuesCount_WhenMultipleDimensionsHaveMultipleDimensionValues()
//         {
//             // Arrange
//             Dimension dimension1 = new Dimension
//             {
//                 Name = "name1",
//                 Description = "desc",
//                 IsActive = 1,
//             };
//             Dimension dimension1Result = await _masterDataBusinessLogic
//                .AddDimensionAsync(dimension1)
//                .ConfigureAwait(false);
//
//             DimensionValue dimension11Value = new DimensionValue
//             {
//                 Value = "dimval11",
//             };
//
//             DimensionValue dimension11ValueResult = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimension11Value,
//                     dimension1Result.Id).ConfigureAwait(false);
//
//             DimensionValue dimension12Value = new DimensionValue
//             {
//                 Value = "dimval12",
//             };
//
//             DimensionValue dimensionValue12Result = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimension12Value,
//                     dimension1Result.Id).ConfigureAwait(false);
//
//
//             Dimension dimension2 = new Dimension
//             {
//                 Name = "name2",
//                 Description = "desc",
//                 IsActive = 1,
//             };
//             Dimension dimension2Result = await _masterDataBusinessLogic
//                .AddDimensionAsync(dimension2)
//                .ConfigureAwait(false);
//
//             DimensionValue dimension21Value = new DimensionValue
//             {
//                 Value = "dimval21",
//             };
//
//             DimensionValue dimension21ValueResult = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimension21Value,
//                     dimension2Result.Id).ConfigureAwait(false);
//
//             DimensionValue dimension22Value = new DimensionValue
//             {
//                 Value = "dimval22",
//             };
//
//             DimensionValue dimensionValue22Result = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimension22Value,
//                     dimension2Result.Id).ConfigureAwait(false);
//
//             // Act
//             long result = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
//
//             // Assert
//             result.Should().Be(4);
//         }
//
//         [Fact]
//         public async Task ReturnDimensionValuesCount_WhenMultipleDimensionValuesAreInTheSystem()
//         {
//             // Arrange
//             Dimension dimension = new Dimension
//             {
//                 Name = "name",
//                 Description = "desc",
//                 IsActive = 1,
//             };
//             Dimension dimensionResult = await _masterDataBusinessLogic
//                .AddDimensionAsync(dimension)
//                .ConfigureAwait(false);
//
//             DimensionValue dimensionValue = new DimensionValue
//             {
//                 Value = "dimval",
//             };
//
//             DimensionValue dimensionValueResult = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimensionValue,
//                     dimensionResult.Id).ConfigureAwait(false);
//
//             DimensionValue dimensionValue2 = new DimensionValue
//             {
//                 Value = "dimval2",
//             };
//
//             DimensionValue dimensionValue2Result = await _masterDataBusinessLogic
//                .AddDimensionValueAsync(
//                     dimensionValue2,
//                     dimensionResult.Id).ConfigureAwait(false);
//
//             // Act
//             long result = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false);
//
//             // Assert
//             result.Should().Be(2);
//         }
//     }
// }

