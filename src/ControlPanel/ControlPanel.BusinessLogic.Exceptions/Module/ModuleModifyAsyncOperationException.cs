using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    public class ModuleModifyAsyncOperationException : Exception
    {
        public ModuleModifyAsyncOperationException()
        {
        }

        protected ModuleModifyAsyncOperationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public ModuleModifyAsyncOperationException(string message) : base(message)
        {
        }

        public ModuleModifyAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}