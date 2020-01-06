namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Company
{
    using System;
    using System.Runtime.Serialization;

    public class CompanyNullInputValueException : Exception
    {
        public CompanyNullInputValueException()
        {
        }

        protected CompanyNullInputValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CompanyNullInputValueException(string message) : base(message)
        {
        }

        public CompanyNullInputValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}