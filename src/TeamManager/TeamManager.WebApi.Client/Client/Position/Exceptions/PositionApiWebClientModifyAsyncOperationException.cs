namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientModifyAsyncOperationException : Exception
    {
        public PositionApiWebClientModifyAsyncOperationException()
        {
        }

        protected PositionApiWebClientModifyAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PositionApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}