// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleGetAllActiveAsyncOperationException : Exception
    {
        public ModuleGetAllActiveAsyncOperationException()
        {
        }

        protected ModuleGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info, context)
        {
        }

        public ModuleGetAllActiveAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleGetAllActiveAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}