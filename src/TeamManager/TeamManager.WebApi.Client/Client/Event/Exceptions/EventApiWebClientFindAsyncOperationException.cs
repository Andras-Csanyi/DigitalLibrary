namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientFindAsyncOperationException : Exception
    {
        public EventApiWebClientFindAsyncOperationException()
        {
        }

        protected EventApiWebClientFindAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public EventApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}