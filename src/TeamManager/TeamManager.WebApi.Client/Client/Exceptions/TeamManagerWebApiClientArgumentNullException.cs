namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TeamManagerWebApiClientArgumentNullException : Exception
    {
        public TeamManagerWebApiClientArgumentNullException()
        {
        }

        protected TeamManagerWebApiClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public TeamManagerWebApiClientArgumentNullException(string message) : base(message)
        {
        }

        public TeamManagerWebApiClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}