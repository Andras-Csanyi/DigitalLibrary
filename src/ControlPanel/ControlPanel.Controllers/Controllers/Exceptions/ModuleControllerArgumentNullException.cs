// <copyright file="ModuleControllerArgumentNullException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Controllers.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class ModuleControllerArgumentNullException : Exception
    {
        public ModuleControllerArgumentNullException()
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

        protected ModuleControllerArgumentNullException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}