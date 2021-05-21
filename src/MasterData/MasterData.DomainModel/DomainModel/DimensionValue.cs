// <copyright file="DimensionValue.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionValue : IHaveId
    {
        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public string Value { get; set; }

        public long Id { get; set; }
    }
}
