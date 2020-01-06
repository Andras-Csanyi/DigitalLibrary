namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionGetAllActiveAsyncOperationException : Exception
    {
        public PositionGetAllActiveAsyncOperationException()
        {
        }

        protected PositionGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public PositionGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public PositionGetAllActiveAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}