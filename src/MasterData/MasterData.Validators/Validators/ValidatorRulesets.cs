// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class ValidatorRulesets
    {
        public const string AddNewDimension = "AddNewDimension";

        public const string AddNewDimensionStructure = "AddNewDimensionStructure";

        public const string AddNewDimensionValue = "AddNewDimensionValue";

        public const string AddSourceFormat = "AddNewTopDimensionStructure";

        public const string DeleteDimension = "DeleteDimension";

        public const string DeleteDimensionStructure = "DeleteDimensionStructure";

        public const string DeleteSourceFormat = "DeleteSourceFormat";

        public const string ModifyDimensionValue = "ModifyDimensionValue";

        public const string UpdateDimension = "UpdateDimension";

        public const string UpdateDimensionStructure = "UpdateDimensionStructure";

        public const string UpdateSourceFormat = "ModifyDimensionStructure";
    }
}