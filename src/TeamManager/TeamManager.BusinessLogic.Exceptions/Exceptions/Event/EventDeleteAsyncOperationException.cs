namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventDeleteAsyncOperationException : Exception
    {
        public EventDeleteAsyncOperationException()
        {
        }

        protected EventDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public EventDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public EventDeleteAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}