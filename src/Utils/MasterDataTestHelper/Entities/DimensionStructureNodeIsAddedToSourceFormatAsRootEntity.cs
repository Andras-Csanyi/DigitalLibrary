namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    public class DimensionStructureNodeIsAddedToSourceFormatAsRootEntity
    {
        public string DimensionStructureNodeKey { get; set; }

        public string ResultKey { get; set; }

        public string SourceFormatKey { get; set; }
    }
}
