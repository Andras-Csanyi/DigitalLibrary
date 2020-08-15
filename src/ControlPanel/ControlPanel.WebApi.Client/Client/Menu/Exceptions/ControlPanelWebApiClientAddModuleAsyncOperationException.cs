// <copyright file="ControlPanelWebApiClientAddModuleAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientAddModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientAddModuleAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientAddModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}