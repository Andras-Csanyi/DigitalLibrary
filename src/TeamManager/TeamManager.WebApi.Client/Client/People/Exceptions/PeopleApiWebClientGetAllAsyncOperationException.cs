namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientGetAllAsyncOperationException : Exception
    {
        public PeopleApiWebClientGetAllAsyncOperationException()
        {
        }

        protected PeopleApiWebClientGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}