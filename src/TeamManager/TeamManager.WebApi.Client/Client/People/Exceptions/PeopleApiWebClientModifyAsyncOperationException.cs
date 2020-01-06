namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientModifyAsyncOperationException : Exception
    {
        public PeopleApiWebClientModifyAsyncOperationException()
        {
        }

        protected PeopleApiWebClientModifyAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}