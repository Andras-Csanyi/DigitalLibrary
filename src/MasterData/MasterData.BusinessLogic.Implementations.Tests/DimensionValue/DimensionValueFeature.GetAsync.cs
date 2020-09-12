// <copyright file="DimensionValueFeature.GetAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat;
    using DigitalLibrary.MasterData.DomainModel;

    using FluentAssertions;

    using Xbehave;

    using Xunit;

    /// <summary>
    /// Test covering Get method of <see cref="DimensionValue"/> operations.
    /// </summary>
    public partial class DimensionValueFeature
    {
        [Scenario]
        public void GetAsync_ReturnsAllDimensionValuesWhenASingleDimensionValueIsInTheSystem()
        {
            Dimension dimension = null;
            "Given there is a dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimensionResult = null;
            "And it is stored in the database"
               .x(async () => dimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue dimensionValue = null;
            "And there is a dimension value"
               .x(() => dimensionValue = new DimensionValue
                {
                    Value = "dimval",
                });

            "And it is added to the Dimension"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(dimensionValue, dimensionResult.Id)
                   .ConfigureAwait(false));

            List<DimensionValue> result = null;
            "When the dimension values are queried"
               .x(async () => result = await _masterDataBusinessLogic.GetDimensionValuesAsync()
                   .ConfigureAwait(false));

            "Then the length of result is 1".x(() => result.Count.Should().Be(1));
        }

        [Scenario]
        public void GetAsync_ReturnsAllDimensionValuesWhenMultipleDimensionsHaveMultipleDimensionValues()
        {
            Dimension dimension1 = null;
            "Given there is a dimension"
               .x(() => dimension1 = new Dimension
                {
                    Name = "name1",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimension1Result = null;
            "And it is stored in the database"
               .x(async () => dimension1Result = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension1)
                   .ConfigureAwait(false));

            DimensionValue dimension11Value = null;
            "And there is a dimension value"
               .x(() => dimension11Value = new DimensionValue
                {
                    Value = "dimval11",
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(
                        dimension11Value,
                        dimension1Result.Id).ConfigureAwait(false));

            DimensionValue dimension12Value = null;
            "And there is a dimension value"
               .x(() => dimension12Value = new DimensionValue
                {
                    Value = "dimval12",
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(
                        dimension12Value,
                        dimension1Result.Id).ConfigureAwait(false));

            Dimension dimension2 = null;
            "And there is a dimension"
               .x(() => dimension2 = new Dimension
                {
                    Name = "name2",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimension2Result = null;
            "And it is stored in the database"
               .x(async () => dimension2Result = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension2)
                   .ConfigureAwait(false));

            DimensionValue dimension21Value = null;
            "And there is a dimension value"
               .x(() => dimension21Value = new DimensionValue
                {
                    Value = "dimval21",
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(
                        dimension21Value,
                        dimension2Result.Id).ConfigureAwait(false));

            DimensionValue dimension22Value = null;
            "And there is a dimension value"
               .x(() => dimension22Value = new DimensionValue
                {
                    Value = "dimval22",
                });

            "And it is stored in the database"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(
                        dimension22Value,
                        dimension2Result.Id).ConfigureAwait(false));

            List<DimensionValue> result = null;
            "When I query the dimension values"
               .x(async () => result = await _masterDataBusinessLogic.GetDimensionValuesAsync().ConfigureAwait(false));

            "Then the length of the result is 4"
               .x(() => result.Count.Should().Be(4));
        }

        [Scenario]
        public void GetAsync_ReturnsAllDimensionValuesWhenMultipleDimensionValuesAreInTheSystem()
        {
            Dimension dimension = null;
            "Given there is a dimension"
               .x(() => dimension = new Dimension
                {
                    Name = "name",
                    Description = "desc",
                    IsActive = 1,
                });

            Dimension dimensionResult = null;
            "And it is stored in the database"
               .x(async () => dimensionResult = await _masterDataBusinessLogic
                   .AddDimensionAsync(dimension)
                   .ConfigureAwait(false));

            DimensionValue dimensionValue1 = null;
            "And there is a dimension value"
               .x(() => dimensionValue1 = new DimensionValue
                {
                    Value = "dimval1",
                });

            "And it is added to the Dimension"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(dimensionValue1, dimensionResult.Id)
                   .ConfigureAwait(false));

            DimensionValue dimensionValue2 = null;
            "And there is a dimension value"
               .x(() => dimensionValue2 = new DimensionValue
                {
                    Value = "dimval2",
                });

            "And it is added to the Dimension"
               .x(async () => await _masterDataBusinessLogic
                   .AddDimensionValueAsync(dimensionValue2, dimensionResult.Id)
                   .ConfigureAwait(false));

            List<DimensionValue> result = null;
            "When the dimension valules are queried"
               .x(async () => result = await _masterDataBusinessLogic.GetDimensionValuesAsync()
                   .ConfigureAwait(false));

            "Then the length of result is 1".x(() => result.Count.Should().Be(2));
        }
    }
}