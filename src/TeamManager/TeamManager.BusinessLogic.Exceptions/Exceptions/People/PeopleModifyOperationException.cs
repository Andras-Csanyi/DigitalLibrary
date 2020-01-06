namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleModifyOperationException : Exception
    {
        public PeopleModifyOperationException()
        {
        }

        protected PeopleModifyOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleModifyOperationException(string message) : base(message)
        {
        }

        public PeopleModifyOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}