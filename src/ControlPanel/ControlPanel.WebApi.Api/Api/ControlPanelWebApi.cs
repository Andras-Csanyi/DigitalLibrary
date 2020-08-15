// <copyright file="ControlPanelWebApi.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Api
{
    public struct ControlPanelWebApi
    {
        private const string Route = "api/ControlPanel/";

        public struct Menu
        {
            public const string Base = ControlPanelWebApi.Route + "Menu";

            public const string GetAll = "GetAll";

            public const string GetAllActive = "GetAllActive";

            public const string Find = "Find";

            public const string Modify = "Modify";

            public const string Delete = "Delete";

            public const string Add = "Add";
        }

        public struct Module
        {
            public const string Base = ControlPanelWebApi.Route + "Module";

            public const string GetAll = "GetAll";

            public const string GetAllActive = "GetAllActive";

            public const string Find = "Find";

            public const string Modify = "Modify";

            public const string Delete = "Delete";

            public const string Add = "Add";
        }
    }
}