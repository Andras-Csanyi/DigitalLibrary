// // <copyright file="DimensionFeature.DeleteAsync.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
// {
//     using System;
//     using System.Collections.Generic;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Linq;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
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
//     /// Tests covering Delete operations.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         public async Task DeleteAsync_DeletesTheItem()
//         {
//             Dimension dimension1 = null;
//             "Given there is a dimension"
//                .x(() => dimension1 = new Dimension
//                 {
//                     Name = "name1",
//                     Description = "desc1",
//                     IsActive = 1,
//                 });
//
//             Dimension dimension1Result = null;
//             "And it is stored in the database"
//                .x(async () => dimension1Result = await _masterDataBusinessLogic.AddDimensionAsync(dimension1)
//                    .ConfigureAwait(false));
//
//             Dimension dimension2 = null;
//             "And there is dimension"
//                .x(() => dimension2 = new Dimension
//                 {
//                     Name = "name2",
//                     Description = "desc2",
//                     IsActive = 1,
//                 });
//
//             Dimension dimension2Result = null;
//             "And it is stored in the database"
//                .x(async () => dimension2Result = await _masterDataBusinessLogic.AddDimensionAsync(dimension2)
//                    .ConfigureAwait(false));
//
//             "When one dimension is deleted"
//                .x(async () => await _masterDataBusinessLogic.DeleteDimensionAsync(dimension2Result)
//                    .ConfigureAwait(false));
//
//             List<Dimension> result = null;
//             "And list of dimensions is queried"
//                .x(async () => result = await _masterDataBusinessLogic.GetDimensionsAsync()
//                    .ConfigureAwait(false));
//
//             "Then the not deleted dimension is in the list"
//                .x(() => result.Where(p => p.Id == dimension1Result.Id).ToList().Count.Should().Be(1));
//             "And the deleted dimension is not in the list"
//                .x(() => result.Where(p => p.Id == dimension2Result.Id).ToList().Count.Should().Be(0));
//         }
//
//         [Scenario]
//         public void DeleteAsync_ThrowsWhenThereIsNoEntity()
//         {
//             Dimension dimension = null;
//             "Given there is a dimension not in the database"
//                .x(() => dimension = new Dimension
//                 {
//                     Id = 100,
//                 });
//
//             Func<Task> action = null;
//             "When I try to delete the dimension not in the database"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.DeleteDimensionAsync(dimension)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then it throws exception"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicDeleteDimensionAsyncOperationException>()
//                    .WithInnerException<MasterDataBusinessLogicNoSuchDimensionEntity>());
//         }
//     }
// }

