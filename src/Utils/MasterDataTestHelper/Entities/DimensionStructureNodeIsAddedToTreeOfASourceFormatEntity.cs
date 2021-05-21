namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    public class DimensionStructureNodeIsAddedToTreeOfASourceFormatEntity
    {
        public string ToBeAddedDimensionStructureNodeKey { get; set; }

        public string ParentDimensionStructureNodeKey { get; set; }

        public string SourceFormatKey { get; set; }

        public string OperationResultKey { get; set; }
    }
}
