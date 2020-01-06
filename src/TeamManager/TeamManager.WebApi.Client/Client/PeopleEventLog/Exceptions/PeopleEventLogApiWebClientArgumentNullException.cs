namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.PeopleEventLog.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PeopleEventLogApiWebClientArgumentNullException : Exception
    {
        public PeopleEventLogApiWebClientArgumentNullException()
        {
        }

        protected PeopleEventLogApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) :
            base(info,
                context)
        {
        }

        public PeopleEventLogApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public PeopleEventLogApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}