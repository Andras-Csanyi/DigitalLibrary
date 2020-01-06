namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientAddAsyncOperationException : Exception
    {
        public CompanyApiWebClientAddAsyncOperationException()
        {
        }

        protected CompanyApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public CompanyApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}