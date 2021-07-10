namespace DigitalLibrary.MasterData.Tests.TestData.SourceFormat
{
    using System.Collections;
    using System.Collections.Generic;

    public class Create_DimensionStructureNode_Validation_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // order of properties:
            // Id
            // IsActive

            // Id is not zero
            yield return new object[] { 1, 1 };

            // IsActive is different than 0 or 1
            yield return new object[] { 0, 2 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
