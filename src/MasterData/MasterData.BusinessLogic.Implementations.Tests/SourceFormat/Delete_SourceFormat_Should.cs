// // <copyright file="Delete_SourceFormat_Should.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
// {
//     using System;
//     using System.Collections.Generic;
//     using System.Diagnostics.CodeAnalysis;
//     using System.Linq;
//     using System.Threading.Tasks;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
//     using DigitalLibrary.MasterData.DomainModel;
//     using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
//     using DigitalLibrary.Utils.Guards;
//
//     using FluentAssertions;
//
//     using Xunit;
//
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public class Delete_SourceFormat_Should : SourceFormatFeature
//     {
//         public Delete_SourceFormat_Should()
//             : base(TestInfo)
//         {
//         }
//
//         private const string TestInfo = nameof(Delete_SourceFormat_Should);
//
//         [Fact]
//         public async Task Delete()
//         {
//             // Arrange
//             SourceFormat first = new SourceFormat
//             {
//                 Name = "first",
//                 Desc = "first",
//                 IsActive = 1,
//             };
//             SourceFormat firstResult = await _masterDataBusinessLogic.AddSourceFormatAsync(first)
//                .ConfigureAwait(false);
//
//             SourceFormat second = new SourceFormat
//             {
//                 Name = "second",
//                 Desc = "second",
//                 IsActive = 1,
//             };
//             SourceFormat secondResult = await _masterDataBusinessLogic.AddSourceFormatAsync(second)
//                .ConfigureAwait(false);
//
//             // Act
//             await _masterDataBusinessLogic.DeleteSourceFormatAsync(secondResult).ConfigureAwait(false);
//
//             // Assert
//             List<SourceFormat> result = await _masterDataBusinessLogic.GetSourceFormatsAsync()
//                .ConfigureAwait(false);
//
//             int expectedAmount = MasterDataDataSample.GetSourceFormatAmount() + 1;
//             result.Count.Should().Be(expectedAmount);
//             result.Where(p => p.Name == first.Name).ToList().Count.Should().Be(1);
//             result.Where(p => p.Name == second.Name).ToList().Count.Should().Be(0);
//         }
//
//         [Fact]
//         public void ThrowException_WhenEntityDoesntExist()
//         {
//             // Arrange
//             SourceFormat sourceFormat = new SourceFormat { Id = 100 };
//
//             // Act
//             Func<Task> action = async () =>
//             {
//                 await _masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat)
//                    .ConfigureAwait(false);
//             };
//
//             // Assert
//             action.Should()
//                .ThrowExactly<MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException>()
//                .WithInnerException<GuardException>();
//         }
//     }
// }

