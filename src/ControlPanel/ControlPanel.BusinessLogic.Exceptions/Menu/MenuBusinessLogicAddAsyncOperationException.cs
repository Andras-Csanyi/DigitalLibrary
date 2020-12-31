// <copyright file="MenuBusinessLogicAddAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MenuBusinessLogicAddAsyncOperationException : Exception
    {
        public MenuBusinessLogicAddAsyncOperationException()
        {
        }

        protected MenuBusinessLogicAddAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info, context)
        {
        }

        public MenuBusinessLogicAddAsyncOperationException(string message)
            : base(message)
        {
        }

        public MenuBusinessLogicAddAsyncOperationException(string message, Exception innerException)
            : base(
                message,
                innerException)
        {
        }
    }
}