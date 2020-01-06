namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientAddAsyncOperationException : Exception
    {
        public TitleApiWebClientAddAsyncOperationException()
        {
        }

        protected TitleApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public TitleApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}