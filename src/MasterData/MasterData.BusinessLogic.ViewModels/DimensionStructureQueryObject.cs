// <copyright file="DimensionStructureQueryObject.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.ViewModels
{
    using System.Collections.Generic;

    public class DimensionStructureQueryObject
    {
        public long GetDimensionsStructuredById { get; set; }

        public List<long> Ids { get; set; }

        public bool IncludeChildrenWhenGetDimensionStructureById { get; set; }
    }
}
