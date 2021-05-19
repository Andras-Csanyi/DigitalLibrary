// <copyright file="DimensionDimensionValue.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionDimensionValue : IHaveId
    {
        public Dimension Dimension { get; set; }

        public long DimensionId { get; set; }

        public DimensionValue DimensionValue { get; set; }

        public long DimensionValueId { get; set; }

        public long Id { get; set; }
    }
}
