// <copyright file="ControlPanelWebApiClientDeleteMenuAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class ControlPanelWebApiClientDeleteMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteMenuAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientDeleteMenuAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientDeleteMenuAsyncOperationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
