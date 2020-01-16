using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.Validators.TestData.TestData
{
    [ExcludeFromCodeCoverage]
    public static class MasterData_DimensionValue_TestData
    {
        public static IEnumerable<object[]> DimensionValue_Modify_TestData = new List<object[]>
        {
            new object[]
            {
                0,
                new DimensionValue(),
                new DimensionValue(),
            },
            new object[]
            {
                1,
                null,
                new DimensionValue(),
            },
            new object[]
            {
                1,
                new DimensionValue(),
                null
            }
        };
    }
}