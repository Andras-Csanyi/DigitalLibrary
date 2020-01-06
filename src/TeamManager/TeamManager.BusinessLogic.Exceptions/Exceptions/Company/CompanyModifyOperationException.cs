namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyModifyOperationException : Exception
    {
        public CompanyModifyOperationException()
        {
        }

        protected CompanyModifyOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public CompanyModifyOperationException(string message) : base(message)
        {
        }

        public CompanyModifyOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}