namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Position
{
    using System;
    using System.Runtime.Serialization;

    public class PositionDoesNotExistsException : Exception
    {
        public PositionDoesNotExistsException()
        {
        }

        protected PositionDoesNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PositionDoesNotExistsException(string message) : base(message)
        {
        }

        public PositionDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}