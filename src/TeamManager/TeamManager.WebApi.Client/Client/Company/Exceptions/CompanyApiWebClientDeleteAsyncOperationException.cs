namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientDeleteAsyncOperationException : Exception
    {
        public CompanyApiWebClientDeleteAsyncOperationException()
        {
        }

        protected CompanyApiWebClientDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public CompanyApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}