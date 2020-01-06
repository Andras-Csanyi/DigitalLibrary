namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Event.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class EventApiWebClientArgumentNullException : Exception
    {
        public EventApiWebClientArgumentNullException()
        {
        }

        protected EventApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public EventApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public EventApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}