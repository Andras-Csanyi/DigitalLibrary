namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientModifyAsyncOperationException : Exception
    {
        public EventApiWebClientModifyAsyncOperationException()
        {
        }

        protected EventApiWebClientModifyAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public EventApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}