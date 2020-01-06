namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientAddAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientAddAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info, context)
        {
        }

        public PeopleEventLogApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}