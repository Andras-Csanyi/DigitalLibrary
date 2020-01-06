namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogGetOperationException : Exception
    {
        public PeopleEventLogGetOperationException()
        {
        }

        protected PeopleEventLogGetOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleEventLogGetOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogGetOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}