// <copyright file="ModuleDoesNotExistsException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class ModuleDoesNotExistsException : Exception
    {
        public ModuleDoesNotExistsException()
        {
        }

        protected ModuleDoesNotExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ModuleDoesNotExistsException(string message)
            : base(message)
        {
        }

        public ModuleDoesNotExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}