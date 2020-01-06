namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientAddAsyncOperationException : Exception
    {
        public PeopleApiWebClientAddAsyncOperationException()
        {
        }

        protected PeopleApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public PeopleApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}