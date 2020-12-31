// <copyright file="ControlPanelWebApiClientModuleArgumentNullException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class ControlPanelWebApiClientArgumentNullException : Exception
    {
        public ControlPanelWebApiClientArgumentNullException()
        {
        }

        protected ControlPanelWebApiClientArgumentNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientArgumentNullException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientArgumentNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}