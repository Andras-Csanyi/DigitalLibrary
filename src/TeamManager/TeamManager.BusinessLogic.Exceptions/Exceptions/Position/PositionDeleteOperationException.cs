namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionDeleteOperationException : Exception
    {
        public PositionDeleteOperationException()
        {
        }

        protected PositionDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PositionDeleteOperationException(string message) : base(message)
        {
        }

        public PositionDeleteOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}