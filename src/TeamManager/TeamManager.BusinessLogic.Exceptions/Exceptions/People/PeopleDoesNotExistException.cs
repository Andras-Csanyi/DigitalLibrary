namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleDoesNotExistException : Exception
    {
        public PeopleDoesNotExistException()
        {
        }

        protected PeopleDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleDoesNotExistException(string message) : base(message)
        {
        }

        public PeopleDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}