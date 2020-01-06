namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientFindAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientFindAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientFindAsyncOperationException(SerializationInfo info,
                                                                        StreamingContext context) : base(
            info, context)
        {
        }

        public PeopleEventLogApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}