// <copyright file="MenuGetAllAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class MenuGetAllAsyncOperationException : Exception
    {
        public MenuGetAllAsyncOperationException()
        {
        }

        public MenuGetAllAsyncOperationException(string message)
            : base(message)
        {
        }

        public MenuGetAllAsyncOperationException(string message, Exception innerException)
            : base(
                message,
                innerException)
        {
        }

        protected MenuGetAllAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}
