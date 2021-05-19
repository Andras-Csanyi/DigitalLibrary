// // <copyright file="DimensionFeature.UpdateAsync.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Features.Dimension
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.BusinessLogic.Features.SourceFormat;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using Xbehave;
//
//     using Xunit;
//
//     /// <summary>
//     /// Tests covering Update scenarios.
//     /// </summary>
//     public partial class DimensionFeature
//     {
//         [Scenario]
//         public void UpdateAsync_UpdatesTheDimension()
//         {
//             // Arrange
//             string name = null;
//             "Given there is a future name value"
//                .x(() => name = "new name");
//
//             string desc = null;
//             "And there is a future desc value"
//                .x(() => desc = "new desc");
//
//             int isActive = 0;
//             "And there is a future is active value"
//                .x(() => isActive = 0);
//
//             Dimension dimension = null;
//             "And there is a dimension"
//                .x(() => dimension = new Dimension
//                 {
//                     Name = "name",
//                     Description = "desc",
//                     IsActive = 0,
//                 });
//
//             Dimension dimensionResult = null;
//             "And dimension is stored in the database"
//                .x(async () => dimensionResult = await _masterDataBusinessLogic.AddDimensionAsync(dimension)
//                    .ConfigureAwait(false));
//
//             "And saved dimension values are modified"
//                .x(() =>
//                 {
//                     dimensionResult.Name = name;
//                     dimensionResult.Description = desc;
//                     dimensionResult.IsActive = isActive;
//                 });
//
//             Dimension result = null;
//             "When I save the modified dimension a result comes back"
//                .x(async () => result = await _masterDataBusinessLogic
//                    .UpdateDimensionAsync(dimensionResult)
//                    .ConfigureAwait(false));
//
//             "Then the returning result is not null".x(() => result.Should().NotBeNull());
//             "And the returning result id equals to dimension's id"
//                .x(() => result.Id.Should().Be(dimensionResult.Id));
//             "And returning result name equals to dimension name"
//                .x(() => result.Name.Should().Be(dimensionResult.Name));
//             "And returning result description equals to dimension description"
//                .x(() => result.Description.Should().Be(dimensionResult.Description));
//             "And returning result is active equals to dimension is active"
//                .x(() => result.IsActive.Should().Be(dimensionResult.IsActive));
//         }
//
//         [Scenario]
//         public void UpdateAsync_ThrowsWhenThereIsNoSuchEntity()
//         {
//             Dimension dimension = null;
//             "Given there is a dimension"
//                .x(() => dimension = new Dimension
//                 {
//                     Id = 299,
//                     Name = "name",
//                     Description = "desc",
//                     IsActive = 0,
//                 });
//
//             Func<Task> action = null;
//             "When a non existing dimension is updated"
//                .x(() => action = async () =>
//                 {
//                     await _masterDataBusinessLogic.UpdateDimensionAsync(dimension)
//                        .ConfigureAwait(false);
//                 });
//
//             "Then an exception is thrown"
//                .x(() => action.Should().ThrowExactly<MasterDataBusinessLogicUpdateDimensionAsyncOperationException>()
//                    .WithInnerException<GuardException>());
//         }
//     }
// }



