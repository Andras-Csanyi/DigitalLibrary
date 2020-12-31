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
    public class ModuleGetAllAsyncOperationException : Exception
    {
        public ModuleGetAllAsyncOperationException()
        {
        }

        protected ModuleGetAllAsyncOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
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
    }
}