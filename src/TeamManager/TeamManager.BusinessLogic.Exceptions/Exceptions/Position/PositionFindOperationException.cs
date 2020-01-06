namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionFindOperationException : Exception
    {
        public PositionFindOperationException()
        {
        }

        protected PositionFindOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PositionFindOperationException(string message) : base(message)
        {
        }

        public PositionFindOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}