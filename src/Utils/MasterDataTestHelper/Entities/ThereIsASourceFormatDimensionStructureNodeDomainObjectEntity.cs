namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    public class ThereIsASourceFormatDimensionStructureNodeDomainObjectEntity
    {
        public string ResultKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string DimensionStructureNodeKey { get; set; }
    }
}