namespace DigitalLibrary.MasterData.Tests.TestData.SourceFormat
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DeleteRootDimensionStructureNode_InputValidation : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 0, 1 };
            yield return new object[] { 1, 0 };
        }
    }
}
