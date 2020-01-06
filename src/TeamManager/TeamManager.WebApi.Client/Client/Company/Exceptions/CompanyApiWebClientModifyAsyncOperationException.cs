namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientModifyAsyncOperationException : Exception
    {
        public CompanyApiWebClientModifyAsyncOperationException()
        {
        }

        protected CompanyApiWebClientModifyAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public CompanyApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}