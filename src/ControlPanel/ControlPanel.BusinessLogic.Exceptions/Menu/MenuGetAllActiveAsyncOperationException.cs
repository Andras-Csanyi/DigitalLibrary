// <copyright file="MenuGetAllActiveAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MenuGetAllActiveAsyncOperationException : Exception
    {
        public MenuGetAllActiveAsyncOperationException()
        {
        }

        public MenuGetAllActiveAsyncOperationException(string message)
            : base(message)
        {
        }

        public MenuGetAllActiveAsyncOperationException(string message, Exception innerException)
            : base(
                message,
                innerException)
        {
        }

        protected MenuGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}