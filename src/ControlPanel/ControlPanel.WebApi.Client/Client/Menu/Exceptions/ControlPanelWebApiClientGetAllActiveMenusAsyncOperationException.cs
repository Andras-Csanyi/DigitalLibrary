// <copyright file="ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllActiveMenusAsyncOperationException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}