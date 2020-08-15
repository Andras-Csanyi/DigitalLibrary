// <copyright file="ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveModulesAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}