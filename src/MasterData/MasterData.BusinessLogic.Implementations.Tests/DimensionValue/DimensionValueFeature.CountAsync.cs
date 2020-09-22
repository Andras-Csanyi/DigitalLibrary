// // <copyright file="DimensionValueFeature.CountAsync.cs" company="Andras Csanyi">
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
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Test cases covering Count operation.
//     /// </summary>
//     public partial class DimensionValueFeature
//     {
//         [Scenario]
//         public void CountAsync_ReturnsDimensionValuesCountWhenASingleDimensionValueIsInTheSystem()
//         {
//             Dimension dimension = null;
//             "Given there is a dimension"
//                .x(() => dimension = new Dimension
//                 {
//                     Name = "name",
//                     Description = "desc",
//                     IsActive = 1,
//                 });
//
//             Dimension dimensionResult = null;
//             "And it is stored in the database"
//                .x(async () => dimensionResult = await _masterDataBusinessLogic
//                    .AddDimensionAsync(dimension)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimensionValue = null;
//             "And there is a dimension value"
//                .x(() => dimensionValue = new DimensionValue
//                 {
//                     Value = "dimval",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimensionValue, dimensionResult.Id)
//                    .ConfigureAwait(false));
//
//             long result = 0;
//             "When count operation is called"
//                .x(async () =>
//                     result = await _masterDataBusinessLogic.CountDimensionValuesAsync().ConfigureAwait(false));
//
//             "Then the result count is 1".x(() => result.Should().Be(1));
//         }
//
//         [Scenario]
//         public void CountAsync_ReturnsDimensionValuesCountWhenMultipleDimensionsHaveMultipleDimensionValues()
//         {
//             Dimension dimension1 = null;
//             "Given there is a dimension"
//                .x(() => dimension1 = new Dimension
//                 {
//                     Name = "name1",
//                     Description = "desc",
//                     IsActive = 1,
//                 });
//
//             Dimension dimension1Result = null;
//             "And it is stored in the database"
//                .x(async () => dimension1Result = await _masterDataBusinessLogic
//                    .AddDimensionAsync(dimension1)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimension11Value = null;
//             "And there is a dimension value"
//                .x(() => dimension11Value = new DimensionValue
//                 {
//                     Value = "dimval11",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimension11Value, dimension1Result.Id)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimension12Value = null;
//             "And there is a dimension value"
//                .x(() => dimension12Value = new DimensionValue
//                 {
//                     Value = "dimval12",
//                 });
//
//             "And dimension value also added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimension12Value, dimension1Result.Id)
//                    .ConfigureAwait(false));
//
//             Dimension dimension2 = null;
//             "And there is another dimension"
//                .x(() => dimension2 = new Dimension
//                 {
//                     Name = "name2",
//                     Description = "desc",
//                     IsActive = 1,
//                 });
//
//             Dimension dimension2Result = null;
//             "And it is stored in the database"
//                .x(async () => dimension2Result = await _masterDataBusinessLogic
//                    .AddDimensionAsync(dimension2)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimension21Value = null;
//             "And there is a dimension value"
//                .x(() => dimension21Value = new DimensionValue
//                 {
//                     Value = "dimval21",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimension21Value, dimension2Result.Id)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimension22Value = null;
//             "And there is a dimension value"
//                .x(() => dimension22Value = new DimensionValue
//                 {
//                     Value = "dimval22",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimension22Value, dimension2Result.Id)
//                    .ConfigureAwait(false));
//
//             long result = 0;
//             "When count is called"
//                .x(async () => result = await _masterDataBusinessLogic.CountDimensionValuesAsync()
//                    .ConfigureAwait(false));
//
//             "Then result length is 4".x(() => result.Should().Be(4));
//         }
//
//         [Scenario]
//         public void CountAsync_ReturnsDimensionValuesCountWhenMultipleDimensionValuesAreInTheSystem()
//         {
//             Dimension dimension = null;
//             "Given there is a dimension"
//                .x(() => dimension = new Dimension
//                 {
//                     Name = "name",
//                     Description = "desc",
//                     IsActive = 1,
//                 });
//
//             Dimension dimensionResult = null;
//             "And it is stored in database"
//                .x(async () => dimensionResult = await _masterDataBusinessLogic
//                    .AddDimensionAsync(dimension)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimensionValue = null;
//             "And there is a dimension value"
//                .x(() => dimensionValue = new DimensionValue
//                 {
//                     Value = "dimval",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimensionValue, dimensionResult.Id)
//                    .ConfigureAwait(false));
//
//             DimensionValue dimensionValue2 = null;
//             "And there is a dimension value"
//                .x(() => dimensionValue2 = new DimensionValue
//                 {
//                     Value = "dimval2",
//                 });
//
//             "And dimension value is added to dimension"
//                .x(async () => await _masterDataBusinessLogic
//                    .AddDimensionValueAsync(dimensionValue2, dimensionResult.Id)
//                    .ConfigureAwait(false));
//
//             long result = 0;
//             "When count is called"
//                .x(async () => result = await _masterDataBusinessLogic.CountDimensionValuesAsync()
//                    .ConfigureAwait(false));
//
//             "The result lengt is".x(() => result.Should().Be(2));
//         }
//     }
// }

