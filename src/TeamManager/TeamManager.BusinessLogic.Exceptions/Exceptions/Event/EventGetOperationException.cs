namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventGetOperationException : Exception
    {
        public EventGetOperationException()
        {
        }

        protected EventGetOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EventGetOperationException(string message) : base(message)
        {
        }

        public EventGetOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}