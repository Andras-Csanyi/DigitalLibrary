namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleGetAllActiveOperationException : Exception
    {
        public PeopleGetAllActiveOperationException()
        {
        }

        protected PeopleGetAllActiveOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleGetAllActiveOperationException(string message) : base(message)
        {
        }

        public PeopleGetAllActiveOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}