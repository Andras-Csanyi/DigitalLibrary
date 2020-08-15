// <copyright file="ControlPanelWebApiClientDeleteModuleAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientDeleteModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientDeleteModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientDeleteModuleAsyncOperationException(SerializationInfo? info,
                                                                              StreamingContext context)
            : base(info, context)
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
    }
}