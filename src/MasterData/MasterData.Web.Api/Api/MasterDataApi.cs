namespace DigitalLibrary.MasterData.Web.Api
{
    /// <summary>
    ///     Digital Library MasterData api endpoint
    /// </summary>
    public struct MasterDataApi
    {
        public const string Route = "api/masterdata";

        public struct SourceFormat
        {
            public const string SourceFormatBase = Route + "/SourceFormat";

            public struct V1
            {
                public const string Add = "v1/Add";

                public const string Update = "v1/Update";

                public const string Delete = "v1/Delete";

                public const string GetAll = "v1/GetAll";

                public const string GetById = "v1/GetById";
            }
        }

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

                public const string GetDimensionsWithoutStructure = "GetDimensionsWithoutStructure";
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

                public const string GetSourceFormats = "GetTopDimensionStructures";

                public const string UpdateDimensionStructure = "UpdateDimensionStructure";

                public const string AddDimensionStructure = "AddDimensionStructure";

                public const string GetDimensionStructures = "GetDimensionStructures";

                public const string DeleteDimensionStructure = "DeleteDimensionStructure";

                public const string GetDimensionStructuresByIds = "GetDimensionStructuresByIds";

                public const string GetDimensionStructureById = "GetDimensionStructureById";
            }
        }
    }
}