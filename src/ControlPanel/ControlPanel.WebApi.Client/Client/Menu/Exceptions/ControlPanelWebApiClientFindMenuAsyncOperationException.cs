// <copyright file="ControlPanelWebApiClientFindMenuAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientFindMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientFindMenuAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientFindMenuAsyncOperationException(string message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientFindMenuAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientFindMenuAsyncOperationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}