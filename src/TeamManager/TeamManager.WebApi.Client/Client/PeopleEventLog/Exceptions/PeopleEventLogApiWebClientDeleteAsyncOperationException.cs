namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientDeleteAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientDeleteAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientDeleteAsyncOperationException(SerializationInfo info,
                                                                          StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleEventLogApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}