namespace DigitalLibrary.Utils.MasterDataTestHelper.Entities
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class KeyExpectedLengthEntity : KeyResultKeyEntity
    {
        public int ExpectedLength { get; set; }
    }
}