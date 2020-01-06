namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientGetAllAsyncOperationException : Exception
    {
        public PositionApiWebClientGetAllAsyncOperationException()
        {
        }

        protected PositionApiWebClientGetAllAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PositionApiWebClientGetAllAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientGetAllAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}