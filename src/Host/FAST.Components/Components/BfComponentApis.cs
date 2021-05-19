// <copyright file="BfComponentApis.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace FAST.Components.Components
{
    /// <summary>
    ///     Api and api values for Bf* components.
    /// </summary>
    public struct BfComponentApis
    {
        /// <summary>
        ///     BfAccordion component Api.
        /// </summary>
        public struct BfAccordion
        {
            public const string ExpandMode = "expand-mode";

            /// <summary>
            ///     BfAccordion Api values for configuration.
            /// </summary>
            public struct ExpandModeValues
            {
                public const string Single = "single";

                public const string Multi = "multi";
            }
        }

        public struct BfAccordionItem
        {
        }

        public struct BfTreeView
        {
            public struct Html
            {
                public const string BfTreeView = "fast-tree-view";
            }
        }

        public struct BfTreeItem
        {
            public struct Html
            {
                public const string BfTreeItem = "fast-tree-item";
            }

            public struct Attributes
            {
                public const string Expanded = "expanded";

                public const string Selected = "selected";

                public struct ExpandedValues
                {
                    public const string Expanded = "true";

                    public const string Closed = "false";
                }

                public struct SelectedValues
                {
                    public const string Selected = "selected";

                    public const string NotSelected = "";
                }
            }
        }
    }
}
