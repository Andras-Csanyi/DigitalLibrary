namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientGetAllAsyncOperationException : Exception
    {
        public EventApiWebClientGetAllAsyncOperationException()
        {
        }

        protected EventApiWebClientGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public EventApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}