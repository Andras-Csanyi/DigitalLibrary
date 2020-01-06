namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Company.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public CompanyApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected CompanyApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info,
                                                                         StreamingContext context) : base(info, context)
        {
        }

        public CompanyApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}