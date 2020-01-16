using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.MasterData.Validators.TestData.TestData
{
    [ExcludeFromCodeCoverage]
    public class MasterData_Dimension_TestData
    {
        public static IEnumerable<object[]> AddDimensionAsync_Validation = new List<object[]>
        {
            new object[] { 1, "name", "desc", 1 },

            new object[] { 0, null, "desc", 1 },
            new object[] { 0, string.Empty, "desc", 1 },
            new object[] { 0, "as", "desc", 1 },

            new object[] { 0, "name", null, 1 },
            new object[] { 0, "name", string.Empty, 1 },
            new object[] { 0, "name", "as", 1 },

            new object[] { 0, "name", "desc", 2 },
        };

        public static IEnumerable<object[]> ModifyDimensionAsync_InputValidation = new List<object[]>
        {
            new object[]
            {
                0, new Dimension(),
            },
            new object[]
            {
                1, null
            }
        };

        public static IEnumerable<object[]> ModifyDimensionAsync_Validation = new List<object[]>
        {
            new object[] { 1, null, "desc", 1 },
            new object[] { 1, string.Empty, "desc", 1 },
            new object[] { 1, "as", "desc", 1 },

            new object[] { 1, "name", null, 1 },
            new object[] { 1, "name", string.Empty, 1 },
            new object[] { 1, "name", "as", 1 },

            new object[] { 1, "name", "desc", 2 },
        };
    }
}