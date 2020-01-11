namespace DigitalLibrary.IaC.MasterData.Web.Api.Api
{
    /// <summary>
    ///     Digital Library MasterData api endpoint
    /// </summary>
    public struct MasterDataApi
    {
        public const string Route = "api/masterdata";

        public struct DimensionAttribute
        {
            public struct V1
            {
                public const string DimensionAttributeBase = Route + "/dimensionproperty/v1";

                public const string Add = "Add";

                public const string Modify = "Modify";

                public const string Delete = "Delete";

                public const string GetAll = "GetAll";
            }
        }

        public struct Dimensions
        {
            public struct V1
            {
                public const string DimensionRouteBase = "api/masterdata/dimension/v1";

                public const string GetAllActive = "GetAllActive";

                public const string GetAll = "GetAll";

                public const string AddNew = "AddNew";

                public const string Modify = "Modify";

                public const string Delete = "Delete";

                public const string Find = "Find";

                public const string GetDimensionById = "GetDimensionById";
            }
        }

        public struct DimensionProperty
        {
            public struct V1
            {
                public const string DimensionPropertyBase = "api/masterdata/dimensioproperty/v1";

                public const string GetAllActive = "GetAllActive";

                public const string GetAll = "GetAll";

                public const string AddNew = "AddNew";

                public const string Modify = "Modify";

                public const string Delete = "Delete";

                public const string Find = "Find";
            }
        }

        public struct DimensionStructure
        {
            public struct V1
            {
                public const string DimensionStructureBase = "api/masterdata/dimensionstructure/v1";

                public const string GetTopDimensionStructures = "GetTopDimensionStructures";

                public const string DeleteTopDimensionStructure = "DeleteTopDimensionStructure";

                public const string UpdateDimensionStructure = "UpdateDimensionStructure";

                public const string UpdateTopDimensionStructure = "UpdateTopDimensionStructure";

                public const string AddTopDimensionStructure = "AddTopDimensionStructure";

                public const string AddDimensionStructure = "AddDimensionStructure";

                public const string GetDimensionStructures = "GetDimensionStructures";

                public const string DeleteDimensionStructure = "DeleteDimensionStructure";
            }
        }
    }
}