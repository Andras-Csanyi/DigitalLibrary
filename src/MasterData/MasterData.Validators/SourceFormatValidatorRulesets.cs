// <copyright file="SourceFormatValidatorRulesets.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Validator ruleset options for <see cref="SourceFormatValidator" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public struct SourceFormatValidatorRulesets
    {
        /// <summary>
        ///     Add operation.
        /// </summary>
        public const string Add = "Add";

        /// <summary>
        ///     Delete operation.
        /// </summary>
        public const string Delete = "Delete";

        /// <summary>
        ///     GetById operation.
        /// </summary>
        public const string GetById = "GetById";

        /// <summary>
        ///     GetByName operation.
        /// </summary>
        public const string GetByName = "GetByName";

        /// <summary>
        ///     Update operation.
        /// </summary>
        public const string Update = "Update";

        /// <summary>
        ///     Ruleset identifier for Inactivate operation.
        /// </summary>
        public const string Inactivate = "Inactivate";
    }
}