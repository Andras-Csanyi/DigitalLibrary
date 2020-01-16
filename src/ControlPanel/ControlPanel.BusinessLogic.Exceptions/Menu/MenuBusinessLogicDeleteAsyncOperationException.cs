using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    public class MenuBusinessLogicDeleteAsyncOperationException : Exception
    {
        public MenuBusinessLogicDeleteAsyncOperationException()
        {
        }

        protected MenuBusinessLogicDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public MenuBusinessLogicDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public MenuBusinessLogicDeleteAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}