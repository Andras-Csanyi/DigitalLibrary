// <copyright file="ControlPanelWebApiClientGetAllMenusAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientGetAllMenusAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllMenusAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientGetAllMenusAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllMenusAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientGetAllMenusAsyncOperationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
