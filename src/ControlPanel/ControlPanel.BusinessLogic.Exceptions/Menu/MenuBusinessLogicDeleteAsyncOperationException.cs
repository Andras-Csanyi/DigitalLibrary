namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

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