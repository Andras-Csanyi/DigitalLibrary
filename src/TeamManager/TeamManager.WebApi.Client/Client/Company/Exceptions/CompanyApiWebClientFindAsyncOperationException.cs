namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientFindAsyncOperationException : Exception
    {
        public CompanyApiWebClientFindAsyncOperationException()
        {
        }

        protected CompanyApiWebClientFindAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public CompanyApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}