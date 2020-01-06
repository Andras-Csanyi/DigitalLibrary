namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionModifyOperationException : Exception
    {
        public PositionModifyOperationException()
        {
        }

        protected PositionModifyOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public PositionModifyOperationException(string message) : base(message)
        {
        }

        public PositionModifyOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}