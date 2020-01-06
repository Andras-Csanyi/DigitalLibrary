namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleAddOperationException : Exception
    {
        public PeopleAddOperationException()
        {
        }

        protected PeopleAddOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleAddOperationException(string message) : base(message)
        {
        }

        public PeopleAddOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}