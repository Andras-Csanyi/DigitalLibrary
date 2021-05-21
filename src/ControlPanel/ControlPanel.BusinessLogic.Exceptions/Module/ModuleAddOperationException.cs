// <copyright file="ModuleAddOperationException.cs" company="Andras Csanyi">
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
    public class ModuleAddOperationException : Exception
    {
        public ModuleAddOperationException()
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

        protected ModuleAddOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
