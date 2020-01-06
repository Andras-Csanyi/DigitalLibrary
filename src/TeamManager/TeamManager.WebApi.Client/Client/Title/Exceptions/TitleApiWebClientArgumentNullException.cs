namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientArgumentNullException : Exception
    {
        public TitleApiWebClientArgumentNullException()
        {
        }

        protected TitleApiWebClientArgumentNullException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public TitleApiWebClientArgumentNullException(string message) : base(message)
        {
        }

        public TitleApiWebClientArgumentNullException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}