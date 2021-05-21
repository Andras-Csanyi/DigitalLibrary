// <copyright file="ModuleNullInputException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class ModuleNullInputException : Exception
    {
        public ModuleNullInputException()
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

        protected ModuleNullInputException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
