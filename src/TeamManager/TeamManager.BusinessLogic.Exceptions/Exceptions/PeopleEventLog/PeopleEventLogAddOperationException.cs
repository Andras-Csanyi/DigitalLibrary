namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.PeopleEventLog
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogAddOperationException : Exception
    {
        public PeopleEventLogAddOperationException()
        {
        }

        protected PeopleEventLogAddOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PeopleEventLogAddOperationException(string message) : base(message)
        {
        }

        public PeopleEventLogAddOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}