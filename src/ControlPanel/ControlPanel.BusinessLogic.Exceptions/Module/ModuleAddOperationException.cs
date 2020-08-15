// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Copyright (c) Andras Csanyi. All rights reserved.
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleAddOperationException : Exception
    {
        public ModuleAddOperationException()
        {
        }

        protected ModuleAddOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ModuleAddOperationException(string message)
            : base(message)
        {
        }

        public ModuleAddOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}