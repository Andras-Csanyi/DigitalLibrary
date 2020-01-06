namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyDoesNotExistException : Exception
    {
        public CompanyDoesNotExistException()
        {
        }

        protected CompanyDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CompanyDoesNotExistException(string message) : base(message)
        {
        }

        public CompanyDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}