namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogEntryDoesNotExistsException : Exception
    {
        public PeopleEventLogEntryDoesNotExistsException()
        {
        }

        protected PeopleEventLogEntryDoesNotExistsException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public PeopleEventLogEntryDoesNotExistsException(string message) : base(message)
        {
        }

        public PeopleEventLogEntryDoesNotExistsException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}