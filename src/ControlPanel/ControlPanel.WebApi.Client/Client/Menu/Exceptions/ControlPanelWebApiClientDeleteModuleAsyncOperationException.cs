// <copyright file="ControlPanelWebApiClientDeleteModuleAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientDeleteModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteModuleAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientDeleteModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientDeleteModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientDeleteModuleAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
