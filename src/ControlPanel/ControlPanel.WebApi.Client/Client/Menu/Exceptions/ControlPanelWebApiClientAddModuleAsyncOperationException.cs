// <copyright file="ControlPanelWebApiClientAddModuleAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientAddModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddModuleAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        protected ControlPanelWebApiClientAddModuleAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
