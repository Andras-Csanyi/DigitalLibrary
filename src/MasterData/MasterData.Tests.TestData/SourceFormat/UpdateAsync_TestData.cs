namespace DigitalLibrary.MasterData.Tests.TestData.SourceFormat
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class UpdateAsync_TestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "asdasd", "asdasd", 1 };
            yield return new object[] { "asdasd", "asdasd asdasd", 0 };
            yield return new object[] { "asdasd asda", "asdasd asdasd", 1 };
        }
    }
}