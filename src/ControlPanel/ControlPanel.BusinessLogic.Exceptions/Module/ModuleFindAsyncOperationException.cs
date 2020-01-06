namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleFindAsyncOperationException : Exception
    {
        public ModuleFindAsyncOperationException()
        {
        }

        protected ModuleFindAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public ModuleFindAsyncOperationException(string message) : base(message)
        {
        }

        public ModuleFindAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}