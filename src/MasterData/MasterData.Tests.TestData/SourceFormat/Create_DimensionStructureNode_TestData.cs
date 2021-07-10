namespace DigitalLibrary.MasterData.Tests.TestData.SourceFormat
{
    using System.Collections;
    using System.Collections.Generic;

    public class Create_DimensionStructureNode_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // order of properties:
            // Id
            // IsActive

            yield return new object[] { 0, 0 };
            yield return new object[] { 0, 1 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
