namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientAddAsyncOperationException : Exception
    {
        public EventApiWebClientAddAsyncOperationException()
        {
        }

        protected EventApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public EventApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}