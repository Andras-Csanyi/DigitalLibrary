// <copyright file="ModuleModifyAsyncOperationException.cs" company="Andras Csanyi">
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
    public class ModuleModifyAsyncOperationException : Exception
    {
        public ModuleModifyAsyncOperationException()
        {
        }

        public ModuleModifyAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleModifyAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModuleModifyAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}