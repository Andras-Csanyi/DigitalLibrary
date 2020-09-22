// // <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// // Copyright (c) Andras Csanyi. All rights reserved.
// //  Licensed under MIT.
// // </copyright>
//
// namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
// {
//     using System;
//     using System.Diagnostics.CodeAnalysis;
//
//     using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
//     using DigitalLibrary.MasterData.Ctx;
//     using DigitalLibrary.MasterData.Validators;
//     using DigitalLibrary.Utils.ControlPanel.DataSample.MasterData;
//     using DigitalLibrary.Utils.Guards;
//
//     using Microsoft.EntityFrameworkCore;
//     using Microsoft.Extensions.Logging;
//
//     using Xbehave;
//
//     using Xunit.Abstractions;
//
//     /// <summary>
//     /// Background steps for <see cref="SourceFormat"/> related test cases.
//     /// </summary>
//     [ExcludeFromCodeCoverage]
//     [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
//     [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
//     public partial class SourceFormatFeature : MasterDataBusinessLogicFeature
//     {
//         public SourceFormatFeature(ITestOutputHelper testOutputHelper)
//             : base(nameof(SourceFormatFeature), testOutputHelper)
//         {
//             ITestOutputHelper helper = testOutputHelper
//              ?? throw new ArgumentNullException("bla");
//         }
//     }
// }

