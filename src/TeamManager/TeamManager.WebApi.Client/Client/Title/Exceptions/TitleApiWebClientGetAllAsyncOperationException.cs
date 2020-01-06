namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientGetAllAsyncOperationException : Exception
    {
        public TitleApiWebClientGetAllAsyncOperationException()
        {
        }

        protected TitleApiWebClientGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public TitleApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}