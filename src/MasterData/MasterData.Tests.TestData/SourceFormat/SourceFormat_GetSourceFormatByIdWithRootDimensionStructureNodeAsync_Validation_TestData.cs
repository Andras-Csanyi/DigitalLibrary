namespace DigitalLibrary.MasterData.Tests.TestData
{
    using System.Collections;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel;

    public class SourceFormat_GetSourceFormatByIdWithRootDimensionStructureNodeAsync_Validation_TestData
        : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
            yield return new object[] { new SourceFormat { Id = 0 } };
        }
    }
}