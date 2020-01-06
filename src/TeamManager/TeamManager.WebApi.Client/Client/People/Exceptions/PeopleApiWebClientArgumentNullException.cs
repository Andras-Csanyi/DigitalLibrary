namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.People.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleApiWebClientArgumentNullException : Exception
    {
        public PeopleApiWebClientArgumentNullException()
        {
        }

        protected PeopleApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public PeopleApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}