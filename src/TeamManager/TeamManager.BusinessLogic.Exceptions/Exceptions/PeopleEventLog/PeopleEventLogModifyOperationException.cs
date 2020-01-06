namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogModifyOperationException : Exception
    {
        public PeopleEventLogModifyOperationException()
        {
        }

        protected PeopleEventLogModifyOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleEventLogModifyOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogModifyOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}