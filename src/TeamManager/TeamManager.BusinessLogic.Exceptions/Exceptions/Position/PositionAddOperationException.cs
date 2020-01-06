namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionAddOperationException : Exception
    {
        public PositionAddOperationException()
        {
        }

        protected PositionAddOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PositionAddOperationException(string message) : base(message)
        {
        }

        public PositionAddOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}