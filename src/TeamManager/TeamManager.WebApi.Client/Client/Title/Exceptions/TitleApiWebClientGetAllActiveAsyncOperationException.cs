namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public TitleApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected TitleApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public TitleApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}