// // <copyright file="DimensionFeature.AddAsync.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
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
//     /// Test cases covering Add operation.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         public void AddAsync_AddsDimension()
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
//             Dimension result = null;
//             "When it is added to the database"
//                .x(async () => result = await _masterDataBusinessLogic.AddDimensionAsync(dimension)
//                    .ConfigureAwait(false));
//
//             "Then the return result is not null"
//                .x(() => result.Should().NotBeNull());
//             "And return result type is the expected"
//                .x(() => result.Should().BeOfType<Dimension>());
//             "And return result id is not zero"
//                .x(() => result.Id.Should().NotBe(0));
//             "And return result name is the expected"
//                .x(() => result.Name.Should().Be(dimension.Name));
//             "And return result description is the expected"
//                .x(() => result.Description.Should().Be(dimension.Description));
//             "And return result is active value is the expected"
//                .x(() => result.IsActive.Should().Be(dimension.IsActive));
//         }
//     }
// }

