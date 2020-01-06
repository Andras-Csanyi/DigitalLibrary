namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.People
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleGetAllOperationException : Exception
    {
        public PeopleGetAllOperationException()
        {
        }

        protected PeopleGetAllOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PeopleGetAllOperationException(string message) : base(message)
        {
        }

        public PeopleGetAllOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}