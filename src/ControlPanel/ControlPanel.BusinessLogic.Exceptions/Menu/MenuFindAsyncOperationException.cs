// <copyright file="MenuFindAsyncOperationException.cs" company="Andras Csanyi">
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
    public class MenuFindAsyncOperationException : Exception
    {
        public MenuFindAsyncOperationException()
        {
        }

        public MenuFindAsyncOperationException(string message)
            : base(message)
        {
        }

        public MenuFindAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected MenuFindAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info,
                context)
        {
        }
    }
}