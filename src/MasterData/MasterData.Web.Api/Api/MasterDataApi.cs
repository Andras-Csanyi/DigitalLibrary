// <copyright file="MasterDataApi.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api
{
    /// <summary>
    ///     Digital Library MasterData api endpoint.
    /// </summary>
    public struct MasterDataApi
    {
        public const string Route = "api/masterdata";

        /// <summary>
        /// <see cref="SourceFormat"/> related endpoints.
        /// </summary>
        public struct SourceFormat
        {
            /// <summary>
            /// Base path.
            /// </summary>
            public const string SourceFormatBase = Route + "/SourceFormat";

            /// <summary>
            /// V1 Api endpoint for <see cref="SourceFormat"/>.
            /// </summary>
            public struct V1
            {
                /// <summary>
                /// Add endpoint path.
                /// </summary>
                public const string Add = "v1/Add";

                /// <summary>
                /// Update endpoint path.
                /// </summary>
                public const string Update = "v1/Update";

                /// <summary>
                /// Delete endpoint path.
                /// </summary>
                public const string Delete = "v1/Delete";

                /// <summary>
                /// GetAll endpoint path.
                /// </summary>
                public const string GetAll = "v1/GetAll";

                /// <summary>
                /// GetActives endpoint path.
                /// </summary>
                public const string GetActives = "v1/GetActives";

                /// <summary>
                /// GetInactives endpoint path.
                /// </summary>
                public const string GetInactives = "v1/GetInactives";

                /// <summary>
                /// GetById endpoint path.
                /// </summary>
                public const string GetById = "v1/GetById";

                /// <summary>
                /// GetByIdWithDimensionStructureTree endpoint path.
                /// </summary>
                public const string GetByIdWithFullDimensionStructureTree = "v1/GetByIdWithDimensionStructureTree";
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

        /// <summary>
        /// <see cref="DimensionStructure"/> related endpoints.
        /// </summary>
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