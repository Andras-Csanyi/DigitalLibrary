namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientGetAllAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientGetAllAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientGetAllAsyncOperationException(SerializationInfo info,
                                                                          StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleEventLogApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}