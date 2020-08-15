// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Copyright (c) Andras Csanyi. All rights reserved.
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuBusinessLogicAddAsyncOperationException : Exception
    {
        public MenuBusinessLogicAddAsyncOperationException()
        {
        }

        protected MenuBusinessLogicAddAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public MenuBusinessLogicAddAsyncOperationException(string message) : base(message)
        {
        }

        public MenuBusinessLogicAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}