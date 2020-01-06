namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyFindOperationException : Exception
    {
        public CompanyFindOperationException()
        {
        }

        protected CompanyFindOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CompanyFindOperationException(string message) : base(message)
        {
        }

        public CompanyFindOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}