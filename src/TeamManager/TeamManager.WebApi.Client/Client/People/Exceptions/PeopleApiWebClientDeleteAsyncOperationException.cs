namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientDeleteAsyncOperationException : Exception
    {
        public PeopleApiWebClientDeleteAsyncOperationException()
        {
        }

        protected PeopleApiWebClientDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PeopleApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}