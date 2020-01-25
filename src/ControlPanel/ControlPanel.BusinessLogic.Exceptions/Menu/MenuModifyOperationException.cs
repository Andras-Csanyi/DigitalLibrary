namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuModifyOperationException : Exception
    {
        public MenuModifyOperationException()
        {
        }

        protected MenuModifyOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MenuModifyOperationException(string message) : base(message)
        {
        }

        public MenuModifyOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}