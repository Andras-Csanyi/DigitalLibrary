// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Copyright (c) Andras Csanyi. All rights reserved.
// Licensed under MIT License

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleNullInputException : Exception
    {
        public ModuleNullInputException()
        {
        }

        protected ModuleNullInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ModuleNullInputException(string message)
            : base(message)
        {
        }

        public ModuleNullInputException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}