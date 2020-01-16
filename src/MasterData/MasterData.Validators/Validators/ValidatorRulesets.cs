using System.Diagnostics.CodeAnalysis;

namespace DigitalLibrary.MasterData.Validators.Validators
{
    [ExcludeFromCodeCoverage]
    public static class ValidatorRulesets
    {
        public const string AddNewDimension = "AddNewDimension";

        public const string AddNewDimensionValue = "AddNewDimensionValue";

        public const string AddNewDimensionStructure = "AddNewDimensionStructure";

        public const string AddNewTopDimensionStructure = "AddNewTopDimensionStructure";

        public const string ModifyDimensionValue = "ModifyDimensionValue";

        public const string ModifyDimension = "ModifyDimension";

        public const string Modify = "Modify";

        public const string Delete = "Delete";

        public const string Find = "Find";

        public const string UpdateDimensionStructure = "UpdateDimensionStructure";

        public const string UpdateTopDimensionStructure = "ModifyDimensionStructure";
    }
}