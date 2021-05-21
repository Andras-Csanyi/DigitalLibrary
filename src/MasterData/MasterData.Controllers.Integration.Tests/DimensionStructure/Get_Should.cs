// // <copyright file="Get_Should.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.Controllers.Integration.Tests.DimensionStructure
// {
//     using System.Collections.Generic;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Linq;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Utils.IntegrationTestFactories.Factories;
//
//     using FluentAssertions;
//
//     using WebApp;
//
//     using Xunit;
//     using Xunit.Abstractions;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     [Collection("DigitalLibrary.IaC.MasterData.Controllers.Integration.Tests")]
//     public class Get_Should : TestBase<DimensionStructure>
//     {
//         public Get_Should(
//             DiLibMasterDataWebApplicationFactory<Startup, DimensionStructure> host,
//             ITestOutputHelper testOutputHelper)
//             : base(host, testOutputHelper)
//         {
//         }
//
//         [Fact(Skip = "Needs refactor")]
//         public async Task Return_All()
//         {
//             // Arrange
//             DimensionStructure dimensionStructure1 = new DimensionStructure
//             {
//                 Name = "list1",
//                 Desc = "list1",
//                 IsActive = 1,
//             };
//             DimensionStructure dimensionStructure1Result = await _masterDataHttpClient
//                .AddDimensionStructureAsync(dimensionStructure1)
//                .ConfigureAwait(false);
//
//             DimensionStructure dimensionStructure2 = new DimensionStructure
//             {
//                 Name = "list2",
//                 Desc = "list2",
//                 IsActive = 1,
//             };
//             DimensionStructure dimensionStructure2Result = await _masterDataHttpClient
//                .AddDimensionStructureAsync(dimensionStructure2)
//                .ConfigureAwait(false);
//
//             DimensionStructure dimensionStructure3 = new DimensionStructure
//             {
//                 Name = "list3",
//                 Desc = "list3",
//                 IsActive = 0,
//             };
//             DimensionStructure dimensionStructure3Result = await _masterDataHttpClient
//                .AddDimensionStructureAsync(dimensionStructure3)
//                .ConfigureAwait(false);
//
//             // Act
//             List<DimensionStructure> dimensionStructures = await _masterDataHttpClient
//                .GetDimensionStructuresAsync()
//                .ConfigureAwait(false);
//
//             // Assert
//             dimensionStructures.Should().NotBeNull();
//             dimensionStructures.Count.Should().Be(3);
//             dimensionStructures.Count(n => n.Name == dimensionStructure1.Name).Should().Be(1);
//             dimensionStructures.Count(n => n.Name == dimensionStructure2.Name).Should().Be(1);
//             dimensionStructures.Count(n => n.Name == dimensionStructure3.Name).Should().Be(1);
//         }
//     }
// }


