namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class KeyExpectedHttpStatusCodeEntity
    {
        public string Key { get; set; }

        public int ExpectedHttpStatusCode { get; set; }
    }
}