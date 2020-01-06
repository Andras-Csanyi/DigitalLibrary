namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientFindAsyncOperationException : Exception
    {
        public PositionApiWebClientFindAsyncOperationException()
        {
        }

        protected PositionApiWebClientFindAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(
                info, context)
        {
        }

        public PositionApiWebClientFindAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}