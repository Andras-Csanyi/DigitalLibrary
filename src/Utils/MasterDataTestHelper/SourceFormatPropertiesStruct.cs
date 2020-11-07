namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Contains properties of <see cref="SourceFormat" />.
    /// </summary>
    [SuppressMessage("ReSharper", "CA1815", Justification = "Reviewed.")]
    public struct SourceFormatPropertiesStruct
    {
        /// <summary>
        ///     SourceFormatDimensionStructure property of <see cref="SourceFormat" />.
        /// </summary>
        public const string SourceFormatDimensionStructure = "SourceFormatDimensionStructure";

        /// <summary>
        ///     Name property of <see cref="SourceFormat" />.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        ///     Desc property of <see cref="SourceFormat" />.
        /// </summary>
        public const string Desc = "Desc";

        /// <summary>
        ///     IsActive property of <see cref="SourceFormat" />.
        /// </summary>
        public const string IsActive = "IsActive";
    }
}