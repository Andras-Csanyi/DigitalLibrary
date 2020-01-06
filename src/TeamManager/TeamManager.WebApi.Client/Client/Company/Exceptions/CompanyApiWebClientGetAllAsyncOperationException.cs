namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientGetAllAsyncOperationException : Exception
    {
        public CompanyApiWebClientGetAllAsyncOperationException()
        {
        }

        protected CompanyApiWebClientGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public CompanyApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}