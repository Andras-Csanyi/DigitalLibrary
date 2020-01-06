namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientFindAsyncOperationException : Exception
    {
        public TitleApiWebClientFindAsyncOperationException()
        {
        }

        protected TitleApiWebClientFindAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public TitleApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}