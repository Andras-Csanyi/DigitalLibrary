// <copyright file="MasterDataApi.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Web.Api
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Digital Library MasterData api endpoint.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public struct MasterDataApi
    {
        public const string Route = "api/masterdata";

        /// <summary>
        ///     <see cref="DimensionStructureNode"/> related endpoints.
        /// </summary>
        public struct DimensionStructureNode
        {
            /// <summary>
            ///     Routebase.
            /// </summary>
            public const string BasePath = Route + "/dimensionstructurenode";

            /// <summary>
            ///     V1 Api.
            /// </summary>
            public struct V1
            {
                public const string Add = "v1/Add";
            }
        }

        /// <summary>
        ///     <see cref="SourceFormatDimensionStructureNode"/> related endpoints.
        /// </summary>
        public struct SourceFormatDimensionStructureNode
        {
            /// <summary>
            ///     Routebase.
            /// </summary>
            public const string BasePath = Route + "/sourceformatdimensionstructurenode";

            /// <summary>
            ///     V1 Api
            /// </summary>
            public struct V1
            {
                /// <summary>
                ///     Path of Add method.
                /// </summary>
                public const string Add = "v1/Add";

                /// <summary>
                ///     Path of Update method.
                /// </summary>
                public const string Update = "v1/Update";

                /// <summary>
                ///     Path of Delete method.
                /// </summary>
                public const string Delete = "v1/Delete";

                /// <summary>
                ///     Path of GetById method.
                /// </summary>
                public const string GetById = "v1/GetById";
            }
        }

        /// <summary>
        ///     <see cref="SourceFormat"/> related endpoints.
        /// </summary>
        public struct SourceFormat
        {
            /// <summary>
            ///     Base path.
            /// </summary>
            public const string BasePath = Route + "/SourceFormat";

            /// <summary>
            ///     V1 Api endpoint for <see cref="SourceFormat"/>.
            /// </summary>
            public struct V1
            {
                /// <summary>
                ///     Add endpoint path.
                /// </summary>
                public const string Add = "v1/Add";

                /// <summary>
                ///     Update endpoint path.
                /// </summary>
                public const string Update = "v1/Update";

                /// <summary>
                ///     Delete endpoint path.
                /// </summary>
                public const string Delete = "v1/Delete";

                /// <summary>
                ///     Inactivate endpoint path.
                /// </summary>
                public const string Inactivate = "v1/Inactivate";

                /// <summary>
                ///     GetAll endpoint path.
                /// </summary>
                public const string GetAll = "v1/GetAll";

                /// <summary>
                ///     GetActives endpoint path.
                /// </summary>
                public const string GetActives = "v1/GetActives";

                /// <summary>
                ///     GetInActives endpoint path.
                /// </summary>
                public const string GetInActives = "v1/GetInactives";

                /// <summary>
                ///     GetById endpoint path.
                /// </summary>
                public const string GetById = "v1/GetById";

                /// <summary>
                ///     GetByIdWithDimensionStructureTree endpoint path.
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
        ///     <see cref="DimensionStructure"/> related endpoints.
        /// </summary>
        public struct DimensionStructure
        {
            /// <summary>
            ///     Describes the route up to version.
            /// </summary>
            public const string RouteBase = "api/masterdata/dimensionstructure";

            public struct V1
            {
                public const string GetSourceFormats = "v1/GetTopDimensionStructures";

                public const string Update = "UpdateDimensionStructure";

                /// <summary>
                ///     Add method route.
                /// </summary>
                public const string Add = "v1/Add";

                /// <summary>
                ///     Delete method route.
                /// </summary>
                public const string Delete = "DeleteDimensionStructure";

                /// <summary>
                ///     GetById method route.
                /// </summary>
                public const string GetById = "v1/GetById";

                /// <summary>
                ///     GetAll method route.
                /// </summary>
                public const string GetAll = "v1/GetAll";

                /// <summary>
                ///     GetActives method route.
                /// </summary>
                public const string GetActives = "v1/GetActives";

                /// <summary>
                ///     GetInActives method route.
                /// </summary>
                public const string GetInActives = "v1/GetInActives";

                /// <summary>
                ///     Invalidate method route.
                /// </summary>
                public const string Inactivate = "v1/Inactivate";
            }
        }
    }
}