namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info,
                                                                                StreamingContext context)
            : base(info, context)
        {
        }

        public PeopleEventLogApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) :
            base(
                message, innerException)
        {
        }
    }
}