namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleGetAllAsyncOperationException : Exception
    {
        public ModuleGetAllAsyncOperationException()
        {
        }

        protected ModuleGetAllAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ModuleGetAllAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleGetAllAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}