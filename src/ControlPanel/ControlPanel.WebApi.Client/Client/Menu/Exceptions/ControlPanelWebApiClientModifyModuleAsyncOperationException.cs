// <copyright file="ControlPanelWebApiClientModifyModuleAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientModifyModuleAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientModifyModuleAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientModifyModuleAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientModifyModuleAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}