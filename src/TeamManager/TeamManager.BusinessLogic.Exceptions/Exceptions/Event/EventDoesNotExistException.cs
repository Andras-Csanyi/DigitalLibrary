namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventDoesNotExistException : Exception
    {
        public EventDoesNotExistException()
        {
        }

        protected EventDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EventDoesNotExistException(string message) : base(message)
        {
        }

        public EventDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}