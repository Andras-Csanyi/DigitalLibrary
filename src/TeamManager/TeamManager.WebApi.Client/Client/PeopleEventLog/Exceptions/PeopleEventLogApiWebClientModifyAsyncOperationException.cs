namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientModifyAsyncOperationException : Exception
    {
        public PeopleEventLogApiWebClientModifyAsyncOperationException()
        {
        }

        protected PeopleEventLogApiWebClientModifyAsyncOperationException(SerializationInfo info,
                                                                          StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleEventLogApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}