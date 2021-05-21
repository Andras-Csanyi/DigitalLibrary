namespace DigitalLibrary.MasterData.Tests.TestData.SourceFormat
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class AppendDimensionStructureNodeAsync_NoSuchObject_TestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, true, 1, false, 1, false };
            yield return new object[] { 1, true, 1, true, 1, false };
            yield return new object[] { 1, true, 1, true, 1, true };
        }
    }
}
