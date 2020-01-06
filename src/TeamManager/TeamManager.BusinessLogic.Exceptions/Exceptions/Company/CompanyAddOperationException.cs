namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyAddOperationException : Exception
    {
        public CompanyAddOperationException()
        {
        }

        protected CompanyAddOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CompanyAddOperationException(string message) : base(message)
        {
        }

        public CompanyAddOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}