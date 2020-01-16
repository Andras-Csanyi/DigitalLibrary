using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
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