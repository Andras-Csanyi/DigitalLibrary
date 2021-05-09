namespace DigitalLibrary.MasterData.Tests.TestData
{
    using System.Collections;
    using System.Collections.Generic;

    public class SourceFormat_UpdateAsync_Validation_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, "asd", "asd", 1 };
            yield return new object[] { 1, null, "asd", 1 };
            yield return new object[] { 1, string.Empty, "asd", 1 };
            yield return new object[] { 1, "   ", "asd", 1 };
            yield return new object[] { 1, "as", "asd", 1 };
            yield return new object[] { 1, "asd", null, 1 };
            yield return new object[] { 1, "asd", string.Empty, 1 };
            yield return new object[] { 1, "asd", "   ", 1 };
            yield return new object[] { 1, "asd", "as", 1 };
            yield return new object[] { 1, "asd", "as", 2 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}