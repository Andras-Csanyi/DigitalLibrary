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
    public class ModuleModifyAsyncOperationException : Exception
    {
        public ModuleModifyAsyncOperationException()
        {
        }

        protected ModuleModifyAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
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
    }
}