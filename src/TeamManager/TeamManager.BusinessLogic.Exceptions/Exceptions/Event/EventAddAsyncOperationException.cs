namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventAddAsyncOperationException : Exception
    {
        public EventAddAsyncOperationException()
        {
        }

        protected EventAddAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public EventAddAsyncOperationException(string message) : base(message)
        {
        }

        public EventAddAsyncOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}