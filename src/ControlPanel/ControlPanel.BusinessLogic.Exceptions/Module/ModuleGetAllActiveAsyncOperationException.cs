// <copyright file="ModuleGetAllActiveAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class ModuleGetAllActiveAsyncOperationException : Exception
    {
        public ModuleGetAllActiveAsyncOperationException()
        {
        }

        protected ModuleGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(
                info, context)
        {
        }

        public ModuleGetAllActiveAsyncOperationException(string message)
            : base(message)
        {
        }

        public ModuleGetAllActiveAsyncOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}