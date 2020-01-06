namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventFindOperationException : Exception
    {
        public EventFindOperationException()
        {
        }

        protected EventFindOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EventFindOperationException(string message) : base(message)
        {
        }

        public EventFindOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}