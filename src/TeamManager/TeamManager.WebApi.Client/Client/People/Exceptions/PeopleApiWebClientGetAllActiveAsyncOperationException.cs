namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public PeopleApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected PeopleApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info,
                                                                        StreamingContext context)
            : base(info, context)
        {
        }

        public PeopleApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public PeopleApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}