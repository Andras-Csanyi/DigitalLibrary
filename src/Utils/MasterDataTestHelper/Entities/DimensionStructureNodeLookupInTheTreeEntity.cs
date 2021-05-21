namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    public class DimensionStructureNodeLookupInTheTreeEntity
    {
        public string Key { get; set; }

        public string SearchForObjectKey { get; set; }
    }
}
