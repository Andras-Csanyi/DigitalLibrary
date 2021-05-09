namespace DigitalLibrary.MasterData.Tests.TestData
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DimensionStructure_Create_Validation_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, "asd", "asd", 0 };
            yield return new object[] { 0, null, "asd", 0 };
            yield return new object[] { 0, string.Empty, "asd", 0 };
            yield return new object[] { 0, "   ", "asd", 0 };
            yield return new object[] { 0, "as", "asd", 0 };
            yield return new object[] { 0, "asd", null, 0 };
            yield return new object[] { 0, "asd", string.Empty, 0 };
            yield return new object[] { 0, "asd", "   ", 0 };
            yield return new object[] { 0, "asd", "as", 0 };
            yield return new object[] { 0, "asd", "as", 2 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}