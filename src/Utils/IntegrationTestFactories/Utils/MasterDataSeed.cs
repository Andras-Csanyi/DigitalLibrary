// <copyright file="MasterDataSeed.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.Utils.IntegrationTestFactories.Utils
{
    using System.Diagnostics.CodeAnalysis;

    using MasterData.Ctx;

    [ExcludeFromCodeCoverage]
    public static class MasterDataSeed
    {
        public static int ActiveDimensionProperty { get; } = 5;

        public static int DimensionsActive { get; set; } = 5;

        public static int DimensionsInActive { get; set; } = 5;

        public static int InActiveDimensionProperty { get; } = 5;

        public static void Seed(MasterDataContext db)
        {
        }
    }
}