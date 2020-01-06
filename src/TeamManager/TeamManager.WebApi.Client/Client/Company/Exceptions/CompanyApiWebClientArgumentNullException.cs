namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientArgumentNullException : Exception
    {
        public CompanyApiWebClientArgumentNullException()
        {
        }

        protected CompanyApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public CompanyApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public CompanyApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}