namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventModifyOperationException : Exception
    {
        public EventModifyOperationException()
        {
        }

        protected EventModifyOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EventModifyOperationException(string message) : base(message)
        {
        }

        public EventModifyOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}