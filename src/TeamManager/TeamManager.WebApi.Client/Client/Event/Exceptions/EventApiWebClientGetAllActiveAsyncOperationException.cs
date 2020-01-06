namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public EventApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected EventApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EventApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public EventApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}