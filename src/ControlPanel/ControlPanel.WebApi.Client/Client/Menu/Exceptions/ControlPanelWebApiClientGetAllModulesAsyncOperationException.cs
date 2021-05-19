// <copyright file="ControlPanelWebApiClientGetAllModulesAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ControlPanelWebApiClientGetAllModulesAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientGetAllModulesAsyncOperationException()
        {
        }

        public ControlPanelWebApiClientGetAllModulesAsyncOperationException(string? message)
            : base(message)
        {
        }

        public ControlPanelWebApiClientGetAllModulesAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected ControlPanelWebApiClientGetAllModulesAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
