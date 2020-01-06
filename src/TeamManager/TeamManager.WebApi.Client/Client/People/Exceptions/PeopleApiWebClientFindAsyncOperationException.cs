namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientFindAsyncOperationException : Exception
    {
        public PeopleApiWebClientFindAsyncOperationException()
        {
        }

        protected PeopleApiWebClientFindAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(
                info, context)
        {
        }

        public PeopleApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}