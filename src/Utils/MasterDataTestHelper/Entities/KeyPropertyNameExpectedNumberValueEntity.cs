namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    public class KeyPropertyNameExpectedNumberValueEntity
    {
        public string Key { get; set; }

        public string PropertyName { get; set; }

        public string ExpectedResultReferenceSourceFormatKey { get; set; }

        public string ReferencedSourceFormatPropertyName { get; set; }
    }
}
