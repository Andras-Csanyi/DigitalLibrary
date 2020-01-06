namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientArgumentNullException : Exception
    {
        public PositionApiWebClientArgumentNullException()
        {
        }

        protected PositionApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(
            info,
            context)
        {
        }

        public PositionApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public PositionApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}