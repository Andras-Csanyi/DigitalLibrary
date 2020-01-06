namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyDeleteOperationException : Exception
    {
        public CompanyDeleteOperationException()
        {
        }

        protected CompanyDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public CompanyDeleteOperationException(string message) : base(message)
        {
        }

        public CompanyDeleteOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}