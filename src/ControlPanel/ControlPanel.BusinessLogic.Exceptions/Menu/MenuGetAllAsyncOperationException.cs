// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuGetAllAsyncOperationException : Exception
    {
        public MenuGetAllAsyncOperationException()
        {
        }

        protected MenuGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public MenuGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public MenuGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}