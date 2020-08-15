// <copyright file="MenuGetAllActiveAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuGetAllActiveAsyncOperationException : Exception
    {
        public MenuGetAllActiveAsyncOperationException()
        {
        }

        protected MenuGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public MenuGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public MenuGetAllActiveAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}