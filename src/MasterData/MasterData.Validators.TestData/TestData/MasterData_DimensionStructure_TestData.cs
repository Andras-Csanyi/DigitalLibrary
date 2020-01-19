using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DigitalLibrary.MasterData.Validators.TestData.TestData
{
    using DomainModel;

    [ExcludeFromCodeCoverage]
    public static class MasterData_DimensionStructure_TestData
    {
        public static IEnumerable<object[]> AddTopDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 1, "name", "desc", 1 },

            new object[] { 0, null, "desc", 1 },
            new object[] { 0, string.Empty, "desc", 1 },
            new object[] { 0, "as", "desc", 1 },

            new object[] { 0, "name", null, 1 },
            new object[] { 0, "name", string.Empty, 1 },
            new object[] { 0, "name", "de", 1 },

            new object[] { 0, "name", "desc", 2 },
        };

        public static IEnumerable<object[]> AddDimensionStructure_Validation_NullObjects = new List<object[]>
        {
            new object[]
            {
                0, new DimensionStructure(),
            },
            new object[]
            {
                1, null
            }
        };

        public static IEnumerable<object[]> AddDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, string.Empty, "desc", 1, 100 },
            new object[] { 0, "as", "desc", 1, 100 },

            new object[] { 0, "name", null, 1, 100 },
            new object[] { 0, "name", string.Empty, 1, 100 },
            new object[] { 0, "name", "de", 1, 100 },

            new object[] { 0, "name", "desc", 2, 100 },

            new object[] { 0, "name", "desc", 1, 0 },
        };

        public static IEnumerable<object[]> ModifyDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, "name", "desc", 1, 1 },

            new object[] { 1, string.Empty, "desc", 1, 1 },
            new object[] { 1, " ", "desc", 1, 1 },
            new object[] { 1, "as", "desc", 1, 1 },
            new object[] { 1, null, "desc", 1, 1 },

            new object[] { 1, "name", string.Empty, 1, 1 },
            new object[] { 1, "name", " ", 1, 1 },
            new object[] { 1, "name", "as", 1, 1 },
            new object[] { 1, "name", null, 1, 1 },

            new object[] { 1, "name", "desc", 2, 1 },

            new object[] { 1, "name", "desc", 1, 0 },
        };

        public static IEnumerable<object[]> ModifyDimensionStructure_TestData = new List<object[]>
        {
            new object[] { "name2", "desc", 1 },
            new object[] { "name", "desc2", 1 },
            new object[] { "name", "desc2", 0 },
        };

        public static IEnumerable<object[]> ModifyTopDimensionStructure_Validation_TestData = new List<object[]>
        {
            new object[] { 0, "name", "desc", 1 },

            new object[] { 1, null, "desc", 1 },
            new object[] { 1, string.Empty, "desc", 1 },
            new object[] { 1, "as", "desc", 1 },

            new object[] { 1, "name", null, 1 },
            new object[] { 1, "name", string.Empty, 1 },
            new object[] { 1, "name", "de", 1 },

            new object[] { 1, "name", "desc", 2 },
        };

        public static IEnumerable<object[]> ModifyTopDimensionStructure_TestData = new List<object[]>
        {
            new object[] { "modif", "asdasd", 1 },
            new object[] { "asdasd", "modif", 1 },
            new object[] { "asdasd", "asdasd", 0 },
        };
    }
}