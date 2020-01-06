namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyGetAllAsyncOperationException : Exception
    {
        public CompanyGetAllAsyncOperationException()
        {
        }

        protected CompanyGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public CompanyGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public CompanyGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}