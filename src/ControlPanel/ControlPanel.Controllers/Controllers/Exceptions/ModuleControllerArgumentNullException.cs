// <copyright file="ModuleControllerArgumentNullException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Controllers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ModuleControllerArgumentNullException : Exception
    {
        public ModuleControllerArgumentNullException()
        {
        }

        protected ModuleControllerArgumentNullException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public ModuleControllerArgumentNullException(string? message)
            : base(message)
        {
        }

        public ModuleControllerArgumentNullException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}