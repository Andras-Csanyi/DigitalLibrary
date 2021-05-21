// <copyright file="ControlPanelWebApiClientFindModuleAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientFindModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientFindModuleAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientFindModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientFindModuleAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}
