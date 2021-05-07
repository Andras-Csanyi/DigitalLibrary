// <copyright file="DimensionStructureValidatorRulesets.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public struct DimensionStructureValidatorRulesets
    {
        public const string AddAsync = "Add";

        public const string Delete = "Delete";

        public const string GetById = "GetById";

        public const string Update = "Update";

        public const string Inactivate = "Inactivate";
    }
}