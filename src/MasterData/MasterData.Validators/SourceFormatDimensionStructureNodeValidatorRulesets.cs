namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Contains available rulesets for <see cref="SourceFormatDimensionStructureNodeValidator"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public struct SourceFormatDimensionStructureNodeValidatorRulesets
    {
        public const string Add = "Add";

        public const string Delete = "Delete";

        public const string GetById = "GetById";

        public const string Update = "Update";
    }
}