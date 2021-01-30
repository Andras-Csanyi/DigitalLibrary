// <copyright file="ModuleDeleteOperationException.cs" company="Andras Csanyi">
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
    public class ModuleDeleteOperationException : Exception
    {
        public ModuleDeleteOperationException()
        {
        }

        public ModuleDeleteOperationException(string message)
            : base(message)
        {
        }

        public ModuleDeleteOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModuleDeleteOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}