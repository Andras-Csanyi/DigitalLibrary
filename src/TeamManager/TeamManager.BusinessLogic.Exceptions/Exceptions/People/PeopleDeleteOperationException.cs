namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleDeleteOperationException : Exception
    {
        public PeopleDeleteOperationException()
        {
        }

        protected PeopleDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleDeleteOperationException(string message) : base(message)
        {
        }

        public PeopleDeleteOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}