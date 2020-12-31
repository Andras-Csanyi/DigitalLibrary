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
    public class MenuFindAsyncOperationException : Exception
    {
        public MenuFindAsyncOperationException()
        {
        }

        protected MenuFindAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info,
                context)
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
    }
}