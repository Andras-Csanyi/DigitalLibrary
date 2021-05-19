// <copyright file="ModuleGetAllAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ModuleGetAllAsyncOperationException : Exception
    {
        public ModuleGetAllAsyncOperationException()
        {
        }

        public ModuleGetAllAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleGetAllAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModuleGetAllAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
