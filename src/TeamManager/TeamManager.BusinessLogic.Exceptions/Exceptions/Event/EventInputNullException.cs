namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Event
{
    using System;
    using System.Runtime.Serialization;

    public class EventInputNullException : Exception
    {
        public EventInputNullException()
        {
        }

        protected EventInputNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EventInputNullException(string message) : base(message)
        {
        }

        public EventInputNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}