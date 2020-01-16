using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
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