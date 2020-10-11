// // <copyright file="AddDimensionStructureRootAsync_Validation_Should.cs" company="Andras Csanyi">
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
//     public class AddDimensionStructureRootAsync_Validation_Should : TestBase
//     {
//         public AddDimensionStructureRootAsync_Validation_Should(ITestOutputHelper outputHelper)
//             : base(outputHelper)
//         {
//         }
//
//         [Fact]
//         public void ThrowException_WhenInputIsNull()
//         {
//             // Arrange
//             _masterDataWebApiClientMock
//                .Setup(m => m.GetSourceFormatWithFullDimensionStructureTreeAsync(It.IsAny<SourceFormat>()))
//                .ReturnsAsync(_sourceFormatWithoutRootDimensionStructure);
//             ISourceFormatBuilderService sourceFormatBuilderService = new SourceFormatBuilderService(
//                 _masterDataWebApiClientMock.Object,
//                 _masterDataValidatorsMock.Object,
//                 _domainEntityHelperServiceMock.Object);
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await sourceFormatBuilderService.OnUpdate(100).ConfigureAwait(false);
//                 await sourceFormatBuilderService.AddDimensionStructureRootAsync(null).ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should().ThrowExactly<GuardException>();
//         }
//     }
// }

