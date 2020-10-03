// // <copyright file="AddDimensionStructureAsync_Validation_Should.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.Ui.WebUI.Test.SourceFormatBuilderService
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Ui.WebUi.Components.SourceFormatBuilder;
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using Moq;
//
//     using Xunit;
//     using Xunit.Abstractions;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class AddDimensionStructureAsync_Validation_Should : TestBase
//     {
//         public AddDimensionStructureAsync_Validation_Should(ITestOutputHelper testOutputHelper)
//             : base(testOutputHelper)
//         {
//         }
//
//         [Fact]
//         public async Task ThrowException_When_DimensionStructureParamIsNull()
//         {
//             // Arrange
//             _masterDataWebApiClientMock
//                .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
//                .ReturnsAsync(_sourceFormat);
//             ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
//                 _masterDataWebApiClientMock.Object,
//                 _masterDataValidatorsMock.Object,
//                 _domainEntityHelperServiceMock.Object);
//             await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await sourceFormatBuilderService.AddDimensionStructureAsync(11, null).ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<GuardException>();
//         }
//
//         [Fact]
//         public async Task ThrowException_When_ParentIdIsNull()
//         {
//             // Arrange
//             _masterDataWebApiClientMock
//                .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
//                .ReturnsAsync(_sourceFormat);
//             ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
//                 _masterDataWebApiClientMock.Object,
//                 _masterDataValidatorsMock.Object,
//                 _domainEntityHelperServiceMock.Object);
//             await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
//             DimensionStructure dimensionStructure = new DimensionStructure();
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await sourceFormatBuilderService.AddDimensionStructureAsync(0, dimensionStructure)
//                    .ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<GuardException>();
//         }
//     }
// }

