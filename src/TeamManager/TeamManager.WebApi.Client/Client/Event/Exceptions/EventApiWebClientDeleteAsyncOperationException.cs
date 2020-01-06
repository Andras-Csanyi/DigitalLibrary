namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientDeleteAsyncOperationException : Exception
    {
        public EventApiWebClientDeleteAsyncOperationException()
        {
        }

        protected EventApiWebClientDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public EventApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}