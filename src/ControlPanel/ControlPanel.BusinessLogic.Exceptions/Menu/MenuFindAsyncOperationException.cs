namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuFindAsyncOperationException : Exception
    {
        public MenuFindAsyncOperationException()
        {
        }

        protected MenuFindAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public MenuFindAsyncOperationException(string message) : base(message)
        {
        }

        public MenuFindAsyncOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}